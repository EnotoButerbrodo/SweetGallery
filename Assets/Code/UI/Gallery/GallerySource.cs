using UnityEngine;
using Zenject;

namespace Code.UI
{
    public class GallerySource : MonoBehaviour
    {
        [SerializeField] private Gallery _gallery;
        [SerializeField] private int _startImagesCount = 4;
        [SerializeField] private int _loadingsImagesCount = 4;
        [SerializeField] private float _scrollPercentToLoad = 0.25f;
        [Inject] private ImageDownloader _imageDownloader;
        
        private void Start()
        {
            CreateStartHolders();
            _gallery.OnScroll += OnGalleryScrolled;
        }

        private void OnGalleryScrolled(Vector2 scrollValue)
        {
            if (scrollValue.y <= _scrollPercentToLoad)
            {
                for (int i = 0; i < _loadingsImagesCount; i++)
                {
                    LoadImage();
                }
            }
        }
        
        private void CreateStartHolders()
        {
            for (int i = 0; i < _startImagesCount; i++)
            {
                LoadImage();
            }
            
            _gallery.ScrollToBegin();
        }
        
        [ContextMenu("LoadImage")]
        private void LoadImage()
        {
            _gallery.AddHolder();
            LoadImageForHolder(_gallery.LastImageIndex);
        }
        
        private void LoadImageForHolder(int imageNumber)
        {
            _imageDownloader.TryGetImage(imageNumber, FitImageHolder);
        }
        
        private void FitImageHolder(bool isImageAvailable
            , int imageNumber, Sprite image)
        {
            if(isImageAvailable == false)
                return;
            
            _gallery.SetHolderImage(imageNumber - 1, image);
        }
        
    }
}
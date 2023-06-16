using UnityEngine;
using Zenject;

namespace Code.UI
{
    public class GallerySource : MonoBehaviour
    {
        [SerializeField] private Gallery _gallery;
        [SerializeField] private int _startImagesCount = 4;
        
        [Inject] private ImageDownloader _imageDownloader;
        
        private int _currentImage = 1;

        private void Awake()
        {
            CreateStartHolders();
        }

        private void CreateStartHolders()
        {
            for (int i = 0; i < _startImagesCount; i++)
            {
                LoadImage();
            }
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
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.UI
{
    public class GallerySource : MonoBehaviour
    {
        [SerializeField] private Gallery _gallery;
        [SerializeField] private string _sourceURL = @"http://data.ikppbb.com/test-task-unity-data/pics";
        [SerializeField] private int _sourceImagesCount = 66;
        
        [SerializeField] private int _startImagesCount = 4;
        [SerializeField] private int _loadingsImagesCount = 4;
        [SerializeField] private float _scrollPercentToLoad = 0.25f;
        
        [Inject] private ImageDownloader _imageDownloader;
        [Inject] private IImageHolderFactory _factory;
        
        private IImageURLBuilder _urlBuilder;

        private Dictionary<string, IImageHolder> _loadingHolders = new();
        private List<Coroutine> _loadingCoroutines;

        private int _currentImage = 1;
        
        private void Start()
        {
            _urlBuilder = new ImageURLBuilder(_sourceURL);
            CreateStartHolders();
            _gallery.OnScroll += OnGalleryScrolled;
        }

        private void OnGalleryScrolled(Vector2 scrollValue)
        {
            if(_currentImage > _sourceImagesCount)
                return;
            
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
            var holder = _factory.Get();
            string imageURL = _urlBuilder.GetURLForImageNumber(_currentImage);
            _currentImage++;
            
            _loadingHolders.Add(imageURL, holder);
            _gallery.AddHolder(holder);
            
            _imageDownloader.TryGetImage(imageURL, FitImageHolder);
        }

        private void OnDisable()
        {
            _imageDownloader.CancelDownloads();
        }

        private void FitImageHolder(bool isImageAvailable
            , string url, Sprite image)
        {
            if(isImageAvailable == false)
                return;

            var holder = _loadingHolders[url];
            holder.SetImage(image);
            _loadingHolders.Remove(url);
        }
        
    }
}
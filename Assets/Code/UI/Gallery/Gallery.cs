using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.UI
{
    public class Gallery : MonoBehaviour
    {
        [SerializeField] private int _startImagesCount = 4;
        [SerializeField] private Transform _content;
        
        [Inject] private IImageHolderFactory _factory;
        [Inject] private ImageDownloader _imageDownloader;

        private List<IImageHolder> _holders = new List<IImageHolder>();

        private int _currentImage = 1;
        private IImageHolder _selectedHolder;
        
        private void Awake()
        {
            CreateStartHolders();
        }

        private void CreateStartHolders()
        {
            for (int i = 1; i < _startImagesCount + 1; i++)
            {
                CreateImageHolder(_currentImage);
                _currentImage++;
            }
        }

        private void CreateImageHolder(int imageNumber)
        {
            var newHolder = _factory.Get();
            newHolder.SetParent(_content);
            newHolder.Selected += UpdateSelectedHolder;
            _holders.Add(newHolder);

            _imageDownloader.TryGetImage(imageNumber, FitImageHolder);
        }

        private void FitImageHolder(bool isImageAvailable
            , int imageNumber, Sprite image)
        {
            if(isImageAvailable == false)
                return;
            
            _holders[imageNumber - 1].SetImage(image);
            
        }
        

        private void UpdateSelectedHolder(IImageHolder holder)
        {
            if(_selectedHolder != null)
                _selectedHolder.Deselect();
            
            _selectedHolder = holder;
        }
    }
}
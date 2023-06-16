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
        
        private IImageHolder _selectedHolder;
        
        private void Awake()
        {
            CreateStartHolders();
        }

        private void CreateStartHolders()
        {
            for (int i = 0; i < _startImagesCount; i++)
            {
                CreateImageHolder();
            }
        }

        private void CreateImageHolder()
        {
            var newHolder = _factory.Get();
            newHolder.SetParent(_content);
            newHolder.Selected += UpdateSelectedHolder;
            
            _imageDownloader.GetNextImage((sprite) => newHolder.SetImage(sprite));
            _holders.Add(newHolder);
        }

        private void UpdateSelectedHolder(IImageHolder holder)
        {
            if(_selectedHolder != null)
                _selectedHolder.Deselect();
            
            _selectedHolder = holder;
        }
    }
}
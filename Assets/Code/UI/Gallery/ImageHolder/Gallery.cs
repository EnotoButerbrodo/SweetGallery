using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.UI.Gallery
{
    public class Gallery : MonoBehaviour
    {
        [SerializeField] private int _startImagesCount = 4;
        [SerializeField] private Transform _content;
        
        [Inject] private IImageHolderFactory _factory;
        
        private List<IImageHolder> _holders = new List<IImageHolder>();

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
            
            _holders.Add(newHolder);
        }
        
    }
}
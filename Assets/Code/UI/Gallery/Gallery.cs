using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
    public class Gallery : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private ScrollRect _scrollRect;
        [Inject] private IImageHolderFactory _factory;

        public event Action<Vector2> OnScroll;
        
        public int LastImageIndex => _holders.Count;
        
        private List<IImageHolder> _holders = new List<IImageHolder>();
        private IImageHolder _selectedHolder;
        
        public void AddHolder()
        {
            var imageHolder = _factory.Get();
            imageHolder.Selected += UpdateSelectedHolder;
            imageHolder.SetParent(_content);
            _holders.Add(imageHolder);

            _scrollRect.verticalScrollbar.SetValueWithoutNotify(0.1f);
        }

        public void SetHolderImage(int imageNumber, Sprite image)
        {
            _holders[imageNumber].SetImage(image);
        }

        private void UpdateSelectedHolder(IImageHolder holder)
        {
            if(_selectedHolder != null)
                _selectedHolder.Deselect();
            
            _selectedHolder = holder;
        }

        private void OnEnable()
        {
            _scrollRect.onValueChanged.AddListener(OnScrolling);
        }

        private void OnScrolling(Vector2 scrollingValue) 
            => OnScroll?.Invoke(scrollingValue);
    }
}
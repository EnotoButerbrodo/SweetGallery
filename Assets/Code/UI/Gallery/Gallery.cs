using System;
using System.Collections.Generic;
using Code.Infrastructure;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
    public class Gallery : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private ScrollRect _scrollRect;

        [Inject] private Game _game;

        public event Action<Vector2> OnScroll;

        private List<IImageHolder> _holders = new List<IImageHolder>();
        private IImageHolder _selectedHolder;
        
        public void AddHolder(IImageHolder holder)
        {
            holder.Selected += OnHolderSelected;
            holder.SetParent(_content);
            _holders.Add(holder);
        }
        

        public void ScrollToBegin()
        {
            _scrollRect.verticalScrollbar.value = 1;
        }

        private void OnHolderSelected(IImageHolder holder)
        {
            if (_selectedHolder != null)
                _selectedHolder.Deselect();

            _selectedHolder = holder;

            Sprite sprite = holder.GetImage();
            if (sprite == null)
                return;

            _game.StateMachine.Enter<ImagePreviewState, Sprite>(sprite);


        }

        private void OnEnable()
        {
            _scrollRect.onValueChanged.AddListener(OnScrolling);
        }

        private void OnScrolling(Vector2 scrollingValue) 
            => OnScroll?.Invoke(scrollingValue);
    }
}
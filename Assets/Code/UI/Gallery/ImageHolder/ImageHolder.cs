using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class ImageHolder : MonoBehaviour, IImageHolder
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image _border;
        [SerializeField] private Button _button;

        public event Action<IImageHolder> Selected;

        public void Deselect()
        {
            _border.enabled = false;
        }

        public void SetImage(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        public Sprite GetImage() 
            => _image.sprite;
        

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent, false);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnSelectButton);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnSelectButton);
        }

        private void OnSelectButton()
        {
            _border.enabled = true;
            Selected?.Invoke(this);
        }
    }
}
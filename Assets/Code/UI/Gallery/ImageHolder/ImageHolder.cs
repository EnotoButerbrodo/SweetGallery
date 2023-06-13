using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Gallery
{
    public class ImageHolder : MonoBehaviour, IImageHolder
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image _border;
        [SerializeField] private Button _button;

        public event Action<IImageHolder> Selected;
        public event Action<IImageHolder> Deselected;
        
        public void SetImage(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
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
            _border.enabled = !_border.enabled;
        }
    }
}
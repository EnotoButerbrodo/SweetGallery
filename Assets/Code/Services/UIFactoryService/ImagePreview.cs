using System;
using Code.Services.ImagePreviewService;
using Code.UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Services.UIService
{
    public class ImagePreview : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [Inject] private IImagePreviewService _imagePreview;

        private void Start()
        {
            SetImage(_imagePreview.ImageToPreview);
        }

        public void SetImage(Sprite image)
        {
            _image.sprite = image;
        }
    }
}
using Code.UI;
using UnityEngine;

namespace Code.Services.UIService
{
    public class ImagePreviewScreen : Screen
    {
        [SerializeField] private ImageHolder _imageHolder;

        public void SetImage(Sprite image)
        {
            _imageHolder.SetImage(image);
        }
    }
}
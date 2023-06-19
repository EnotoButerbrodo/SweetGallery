using UnityEngine;

namespace Code.Services.UIService
{
    public class BeheviourUIFactory : MonoBehaviour, IUIFactory
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private ImagePreviewScreen _imagePreviewScreen;
        public LoadingScreen GetLoadingScreen() => _loadingScreen;
        public ImagePreviewScreen GetImagePreviewScreen() => _imagePreviewScreen;
    }
}
using UnityEngine;

namespace Code.Services.UIService
{
    public class BeheviourUIFactory : MonoBehaviour, IUIFactory
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        public LoadingScreen GetLoadingScreen() => _loadingScreen;
    }
}
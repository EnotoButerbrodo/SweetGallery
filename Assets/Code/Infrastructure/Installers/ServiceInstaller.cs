using Code.Services;
using Code.Services.UIService;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;
        [SerializeField] private BeheviourUIFactory _uiFactory;
        
        public override void InstallBindings()
        {
            BindCoroutineRunner();
            BindUIFactory();
        }

        private void BindUIFactory()
        {
            Container
                .Bind<IUIFactory>()
                .To<BeheviourUIFactory>()
                .FromInstance(_uiFactory)
                .AsSingle();
            
            DontDestroyOnLoad(_uiFactory.gameObject);
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromInstance(_coroutineRunner)
                .AsSingle();
            
            DontDestroyOnLoad(_coroutineRunner);
        }
    }
}
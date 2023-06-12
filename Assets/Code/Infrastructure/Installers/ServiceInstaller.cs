using Code.Services;
using Code.Services.UIService;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private BeheviourUIFactory _uiFactory;
        
        public override void InstallBindings()
        {
            BindCoroutineRunner();
            BindUIFactory();
        }

        private void BindCoroutineRunner()
        {
            CoroutineRunner coroutineRunner = Container
                .InstantiateComponentOnNewGameObject<CoroutineRunner>();
            
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromInstance(coroutineRunner)
                .AsSingle();
            
            DontDestroyOnLoad(coroutineRunner);
        }

        private void BindUIFactory()
        {
            BeheviourUIFactory uiFactory = Container
                .InstantiatePrefabForComponent<BeheviourUIFactory>(_uiFactory);
            
            Container
                .Bind<IUIFactory>()
                .To<BeheviourUIFactory>()
                .FromInstance(_uiFactory)
                .AsSingle();
            
            DontDestroyOnLoad(uiFactory);
        }
    }
}
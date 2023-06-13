using Code.Services.UIService;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class UIFactoryInstaller : MonoInstaller
    {
        [SerializeField] private BeheviourUIFactory _uiFactory;

        public override void InstallBindings()
        {
            BindUIFactory();
        }
        
        private void BindUIFactory()
        {
            BeheviourUIFactory uiFactory = Container
                .InstantiatePrefabForComponent<BeheviourUIFactory>(_uiFactory);
            
            Container
                .Bind<IUIFactory>()
                .To<BeheviourUIFactory>()
                .FromInstance(uiFactory)
                .AsSingle();
        }
    }
}
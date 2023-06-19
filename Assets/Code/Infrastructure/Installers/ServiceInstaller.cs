using Code.Services;
using Code.Services.ImagePreviewService;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        
        public override void InstallBindings()
        {
            BindCoroutineRunner();
            BindImagePreviewService();
        }

        private void BindImagePreviewService()
        {
            Container
                .Bind<IImagePreviewService>()
                .To<ImagePreviewService>()
                .FromNew()
                .AsSingle();
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

        
    }
}
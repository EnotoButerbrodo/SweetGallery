using Code.Services;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        
        public override void InstallBindings()
        {
            BindCoroutineRunner();
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
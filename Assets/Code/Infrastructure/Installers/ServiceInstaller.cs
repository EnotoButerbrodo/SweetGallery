using Code.Services;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;
        
        public override void InstallBindings()
        {
            BindCoroutineRunner();
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
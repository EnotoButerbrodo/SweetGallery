using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class GameBootstrapInstaller : MonoInstaller
    {
        [SerializeField] private GameBootstrap _gameBootstrap;
        
        public override void InstallBindings()
        {
            InstallGameBootstap();
        }

        private void InstallGameBootstap()
        {
            DontDestroyOnLoad(_gameBootstrap);
        }
    }
}
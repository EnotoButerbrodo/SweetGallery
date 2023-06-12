using Zenject;

namespace Code.Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGame();
        }
        
        private void BindGame()
        {
            IGameStatesFactory statesFactory = new GameStatesFactory(Container);
            GameStateMachine stateMachine = new GameStateMachine(statesFactory);
            Game game = new Game(stateMachine);

            Container
                .Bind<Game>()
                .FromInstance(game)
                .AsSingle();

        }
    }
}
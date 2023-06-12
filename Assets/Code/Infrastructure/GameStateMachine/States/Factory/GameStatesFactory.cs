using Code.Services;
using EnotoButerbrodo.StateMachine;
using Zenject;

namespace Code.Infrastructure
{
    public class GameStatesFactory : IGameStatesFactory
    {
        private DiContainer _container;

        public GameStatesFactory(DiContainer container)
        {
            _container = container;
        }

        public IState GetInitialState(GameStateMachine context)
            => new GameInitialState(context);


        public IPayloadedState<LoadSceneArgs> GetLoadSceneState(GameStateMachine context)
            => new LoadSceneState(_container.Resolve<ICoroutineRunner>());

        public IState GetMainMenuState(GameStateMachine context)
            => new MainMenuState(context);
    }
}
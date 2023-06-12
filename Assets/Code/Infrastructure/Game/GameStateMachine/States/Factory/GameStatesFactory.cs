using Code.Services;
using Code.Services.UIService;
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
            => new LoadSceneState(
                  _container.Resolve<ICoroutineRunner>()
                , _container.Resolve<IUIFactory>());

        public IState GetMainMenuState(GameStateMachine context)
            => new MainMenuState(context);

        public IState GetGalleryMenuState(GameStateMachine context)
            => new GalleryMenuState(context);
    }
}
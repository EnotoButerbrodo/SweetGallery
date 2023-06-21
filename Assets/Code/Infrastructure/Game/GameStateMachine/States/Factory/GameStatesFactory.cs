using Code.Services;
using Code.Services.ImagePreviewService;
using Code.Services.UIService;
using Code.UI;
using EnotoButerbrodo.StateMachine;
using UnityEngine;
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
            => new GameInitialState(context
            , _container.Resolve<IInputService>());


        public IPayloadedState<LoadSceneArgs> GetLoadSceneState(GameStateMachine context)
            => new LoadSceneState(
                  _container.Resolve<ICoroutineRunner>()
                , _container.Resolve<IUIFactory>());

        public IState GetMainMenuState(GameStateMachine context)
            => new MainMenuState(context);

        public IState GetGalleryState(GameStateMachine context)
            => new GalleryState(context);

        public IPayloadedState<Sprite> GetImagePreviewState(GameStateMachine context)
            => new ImagePreviewState(context
                , _container.Resolve<IImagePreviewService>());
    }
}
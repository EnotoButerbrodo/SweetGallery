using EnotoButerbrodo.StateMachine;
using UnityEngine;

namespace Code.Infrastructure
{
    public interface IGameStatesFactory
    {
        public IState GetInitialState(GameStateMachine context);
        public IPayloadedState<LoadSceneArgs> GetLoadSceneState(GameStateMachine context);
        public IState GetMainMenuState(GameStateMachine context);
        public IState GetGalleryState(GameStateMachine context);
        IPayloadedState<Sprite> GetImagePreviewState(GameStateMachine gameStateMachine);
    }
}
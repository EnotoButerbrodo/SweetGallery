using EnotoButerbrodo.StateMachine;
using UnityEngine.TextCore.LowLevel;

namespace Code.Infrastructure
{
    public interface IGameStatesFactory
    {
        public IState GetInitialState(GameStateMachine context);
        public IPayloadedState<LoadSceneArgs> GetLoadSceneState(GameStateMachine context);

        public IState GetMainMenuState(GameStateMachine context);
    }
}
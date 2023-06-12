using System;
using System.Collections.Generic;
using EnotoButerbrodo.StateMachine;


namespace Code.Infrastructure
{
    public sealed class GameStateMachine : StateMachine
    {
        private IGameStatesFactory _factory;

        public GameStateMachine(IGameStatesFactory factory)
        {
            _factory = factory;
            _states = GetStates();
        }

        private Dictionary<Type, IExitableState> GetStates()
        {
            return new Dictionary<Type, IExitableState>()
            {
                [typeof(GameInitialState)] = _factory.GetInitialState(context: this),
                [typeof(LoadSceneState)] = _factory.GetLoadSceneState(this),
                [typeof(MainMenuState)] = _factory.GetMainMenuState(this)
            };
        }
    }
}
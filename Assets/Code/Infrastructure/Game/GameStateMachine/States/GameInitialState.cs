using EnotoButerbrodo.StateMachine;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

namespace Code.Infrastructure
{
    public class GameInitialState : IState
    {
        private GameStateMachine _context;

        public GameInitialState(GameStateMachine context)
        {
            _context = context;
        }

        public void Enter()
        {
            SetPortaitOrientation();
            LoadMainMenu();
        }

        private void SetPortaitOrientation()
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }

        private void LoadMainMenu()
        {
            _context.Enter<MainMenuState>();
        }

        public void Exit()
        {
        }
    }
}
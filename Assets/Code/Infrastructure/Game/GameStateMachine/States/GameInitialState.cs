using EnotoButerbrodo.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            SetPortairOrientation();
            LoadMainMenu();
        }

        private void SetPortairOrientation()
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
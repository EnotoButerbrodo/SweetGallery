using EnotoButerbrodo.StateMachine;
using UnityEngine.SceneManagement;

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
            LoadMainMenu();
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
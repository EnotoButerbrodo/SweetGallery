using EnotoButerbrodo.StateMachine;

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
            _context.Enter<LoadSceneState, LoadSceneArgs>(
                new LoadSceneArgs(SceneNames.MainMenuScene
                    , onLoadCallback: EnterMainMenuState));
        }

        private void EnterMainMenuState()
            => _context.Enter<MainMenuState>();
        

        public void Exit()
        {
        }
    }
}
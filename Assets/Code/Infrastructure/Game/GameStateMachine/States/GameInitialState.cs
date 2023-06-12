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
            CheckStartFromInitialScene();
            LoadMainMenu();
        }

        private void CheckStartFromInitialScene()
        {
            if(SceneManager.GetActiveScene().name == SceneNames.InitialScene)
                return;
            
            _context.Enter<LoadSceneState, LoadSceneArgs>(
                new LoadSceneArgs(sceneName: SceneNames.InitialScene
                                  , onLoadCallback: EnterInitialState));
        }

        private void EnterInitialState() 
            => _context.Enter<GameInitialState>();

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
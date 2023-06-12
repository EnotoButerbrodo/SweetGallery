using EnotoButerbrodo.StateMachine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public class MainMenuState : IState
    {
        private GameStateMachine _context;

        public MainMenuState(GameStateMachine context)
        {
            _context = context;
        }

        public void Enter()
        {
            if(!InMainMenuScene())
                LoadMainMenuScene();
        }

        private bool InMainMenuScene() 
            => SceneManager.GetActiveScene().name == SceneNames.MainMenuScene;

        private void LoadMainMenuScene() =>
            _context.Enter<LoadSceneState, LoadSceneArgs>(
                new LoadSceneArgs(SceneNames.MainMenuScene));

        public void Exit()
        {
        }
    }
}
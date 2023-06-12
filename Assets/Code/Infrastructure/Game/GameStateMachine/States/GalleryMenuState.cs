using EnotoButerbrodo.StateMachine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public class GalleryMenuState : IState
    {
        private readonly GameStateMachine _context;

        public GalleryMenuState(GameStateMachine context)
        {
            _context = context;
        }

        public void Enter()
        {
            if(!InGalleryScene())
                LoadGalleryScene();
        }

        public void Exit()
        {
            
        }
        
        private bool InGalleryScene() 
            => SceneManager.GetActiveScene().name == SceneNames.GalleryMenuScene;

        private void LoadGalleryScene() =>
            _context.Enter<LoadSceneState, LoadSceneArgs>(
                new LoadSceneArgs(SceneNames.GalleryMenuScene));
    }
}
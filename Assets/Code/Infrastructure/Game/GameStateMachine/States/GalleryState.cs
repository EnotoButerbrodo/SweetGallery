using EnotoButerbrodo.StateMachine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public class GalleryState : IState
    {
        private readonly GameStateMachine _context;

        public GalleryState(GameStateMachine context)
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
            => SceneManager.GetActiveScene().name == SceneNames.GalleryScene;

        private void LoadGalleryScene() =>
            _context.Enter<LoadSceneState, LoadSceneArgs>(
                new LoadSceneArgs(SceneNames.GalleryScene));
    }
}
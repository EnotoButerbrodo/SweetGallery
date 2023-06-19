using Code.Services.UIService;
using Code.UI;
using EnotoButerbrodo.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public sealed class ImageViewState : IPayloadedState<Sprite>
    {
        private readonly GameStateMachine _context;
        private readonly IUIFactory _uiFactory;

        private ImagePreviewScreen _screen;

        public ImageViewState(GameStateMachine context, IUIFactory uiFactory)
        {
            _context = context;
            _uiFactory = uiFactory;
        }

        public void Enter(Sprite payload)
        {
            if (SceneManager.GetActiveScene().name != SceneNames.ImageViewScene)
            {
                LoadImageViewScene(payload);
                return;
            }
            _screen = _uiFactory.GetImagePreviewScreen();
            _screen.SetImage(payload);
            _screen.Show();
            
        }

        private void LoadImageViewScene(Sprite payload)
        {
            _context.Enter<LoadSceneState, LoadSceneArgs>(
                new LoadSceneArgs(SceneNames.ImageViewScene
                    , () => EnterThisState(payload)));
        }

        private void EnterThisState(Sprite payload)
        {
            _context.Enter<ImageViewState, Sprite>(payload);
        }

        public void Exit()
        {
            _screen?.Hide();
        }
    }
}
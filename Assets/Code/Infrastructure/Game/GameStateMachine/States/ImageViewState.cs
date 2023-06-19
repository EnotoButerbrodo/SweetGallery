using Code.Services.ImagePreviewService;
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
        private readonly IImagePreviewService _imagePreviewService;
        

        public ImageViewState(GameStateMachine context, IImagePreviewService imagePreviewService)
        {
            _context = context;
            _imagePreviewService = imagePreviewService;
        }

        public void Enter(Sprite payload)
        {
            if (SceneManager.GetActiveScene().name != SceneNames.ImageViewScene)
            {
                LoadImageViewScene(payload);
                return;
            }

            _imagePreviewService.ImageToPreview = payload;

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
        }
    }
}
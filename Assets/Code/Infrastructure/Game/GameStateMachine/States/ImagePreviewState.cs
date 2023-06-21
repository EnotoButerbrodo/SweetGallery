using Code.Services.ImagePreviewService;
using EnotoButerbrodo.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public sealed class ImagePreviewState : IPayloadedState<Sprite>
    {
        private readonly GameStateMachine _context;
        private readonly IImagePreviewService _imagePreviewService;

        private ScreenOrientation _oldScreenOrientation;

        public ImagePreviewState(GameStateMachine context, IImagePreviewService imagePreviewService)
        {
            _context = context;
            _imagePreviewService = imagePreviewService;
        }

        public void Enter(Sprite payload)
        {
            if (!InImagePreviewScene())
            {
                LoadImageViewScene(payload);
                return;
            }
            SetPreviewImage(payload);
            SetDeviceAutoRotationMode();
        }
        
        public void Exit()
        {
            ReturnDeviceRotationMode();
        }

        private void SetPreviewImage(Sprite payload) 
            => _imagePreviewService.ImageToPreview = payload;

        private void SetDeviceAutoRotationMode()
        {
            _oldScreenOrientation = Screen.orientation;
            Screen.orientation = ScreenOrientation.AutoRotation;
        }

        private bool InImagePreviewScene()
            => SceneManager.GetActiveScene().name == SceneNames.ImagePreviewScene;
        

        private void LoadImageViewScene(Sprite payload)
        {
            _context.Enter<LoadSceneState, LoadSceneArgs>(
                new LoadSceneArgs(SceneNames.ImagePreviewScene
                    , () => EnterThisState(payload)));
        }

        private void EnterThisState(Sprite payload) 
            => _context.Enter<ImagePreviewState, Sprite>(payload);

        private void ReturnDeviceRotationMode()
            => Screen.orientation = _oldScreenOrientation;
        
       
    }
}
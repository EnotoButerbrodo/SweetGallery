using System;
using UnityEngine.InputSystem;

namespace Code.Services
{
    public class InputService : IInputService
    {
        public event Action BackButtonPressed;

        private readonly ControllScheme _controllScheme;

        public InputService()
        {
            _controllScheme = new ControllScheme();
        }

        private void OnBackButton(InputAction.CallbackContext obj)
        {
            BackButtonPressed?.Invoke();
        }

        public void Enable()
        {
            _controllScheme.Enable();

            _controllScheme.UI.Back.performed += OnBackButton;
        }

        public void Disable()
        {
            _controllScheme.Disable();
            
            _controllScheme.UI.Back.performed -= OnBackButton;
        }
    }
}
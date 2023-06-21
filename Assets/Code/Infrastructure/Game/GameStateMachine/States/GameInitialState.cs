using Code.Services;
using EnotoButerbrodo.StateMachine;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

namespace Code.Infrastructure
{
    public sealed class GameInitialState : IState
    {
        private readonly GameStateMachine _context;
        private readonly IInputService _inputService;

        public GameInitialState(GameStateMachine context
        , IInputService inputService)
        {
            _context = context;
            _inputService = inputService;
        }

        public void Enter()
        {
            SetPortaitOrientation();
            EnableInput();
            LoadMainMenu();
        }
        
        public void Exit()
        {
        }

        private void EnableInput() 
            => _inputService.Enable();

        private void SetPortaitOrientation() 
            => Screen.orientation = ScreenOrientation.Portrait;

        private void LoadMainMenu() 
            => _context.Enter<MainMenuState>();

        
    }
}
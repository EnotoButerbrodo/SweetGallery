﻿using EnotoButerbrodo.StateMachine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public sealed class MainMenuState : IState
    {
        private readonly GameStateMachine _context;

        public MainMenuState(GameStateMachine context)
        {
            _context = context;
        }

        public void Enter()
        {
            if(!InMainMenuScene())
                LoadMainMenuScene();
        }
        
        public void Exit()
        {
        }

        private bool InMainMenuScene() 
            => SceneManager.GetActiveScene().name == SceneNames.MainMenuScene;

        private void LoadMainMenuScene() =>
            _context.Enter<LoadSceneState, LoadSceneArgs>(
                new LoadSceneArgs(SceneNames.MainMenuScene));

       
    }
}
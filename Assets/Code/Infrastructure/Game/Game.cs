﻿namespace Code.Infrastructure.Installers
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(GameStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
    }
}
using System;
using Code.Services;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class GameBootstrap : MonoBehaviour, ICoroutineRunner
    {
        [Inject] private Game _game;

        private void Awake()
        {
            _game.StateMachine.Enter<GameInitialState>();
        }
    }
}
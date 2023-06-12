using System;
using Code.Services;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class GameBootstrap : MonoBehaviour
    {
        [Inject] private Game _game;

        private void Awake()
        {
            _game.StateMachine.Enter<GameInitialState>();
            DontDestroyOnLoad(this);
        }
    }
}
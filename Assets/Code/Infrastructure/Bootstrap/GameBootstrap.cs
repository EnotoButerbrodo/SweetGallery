using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class GameBootstrap : MonoBehaviour
    {
        [Inject] private Game _game;

        private void Start()
        {
            _game.StateMachine.Enter<GameInitialState>();
            DontDestroyOnLoad(this);
        }
    }
}
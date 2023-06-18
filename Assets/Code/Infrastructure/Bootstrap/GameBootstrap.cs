using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class GameBootstrap : MonoBehaviour
    {
        [Inject] private Game _game;

        private void Start()
        {
            Debug.Log("Bootsrap");
            _game.StateMachine.Enter<GameInitialState>();
            DontDestroyOnLoad(this);
        }
    }
}
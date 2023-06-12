using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.Infrastructure
{
    public class StartFromInitialSceneHandler : MonoBehaviour
    {
        private void Awake()
        {
            if (!IsGameInitiated()) 
                LoadInitialScene();
        }

        private bool IsGameInitiated() 
            => FindObjectOfType<GameBootstrap>() != null;

        private static void LoadInitialScene() 
            => SceneManager.LoadScene(SceneNames.InitialScene);
    }
}
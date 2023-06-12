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

        private static void LoadInitialScene() 
            => SceneManager.LoadScene(SceneNames.InitialScene);

        private bool IsGameInitiated() 
            => FindObjectOfType<GameBootstrap>() != null;
    }
}
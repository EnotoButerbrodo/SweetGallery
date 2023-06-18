using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public class StartFromInitialSceneHandler : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("InitiaalSceneHandler");
            if (!IsGameInitiated()) 
                LoadInitialScene();
        }

        private bool IsGameInitiated() 
            => FindObjectOfType<GameBootstrap>() != null;

        private static void LoadInitialScene() 
            => SceneManager.LoadScene(SceneNames.InitialScene);
    }
}
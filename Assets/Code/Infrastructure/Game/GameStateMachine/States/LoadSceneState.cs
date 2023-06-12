using System.Collections;
using Code.Services;
using Code.Services.UIService;
using EnotoButerbrodo.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{

    public class LoadSceneState : IPayloadedState<LoadSceneArgs>
    {
        private ICoroutineRunner _coroutineRunner;
        private IUIFactory _uiFactory;

        private LoadingScreen _loadingScreen;

        public LoadSceneState(ICoroutineRunner coroutineRunner
            , IUIFactory uiFactory)
        {
            _coroutineRunner = coroutineRunner;
            _uiFactory = uiFactory;
            
            _loadingScreen = _uiFactory.GetLoadingScreen();
        }

        public void Enter(LoadSceneArgs payload)
        {
            _loadingScreen.Show();
            _loadingScreen.SetProgressPercent(0);
            
            _coroutineRunner.StartCoroutine(LoadScene(payload));
        }

        public void Exit()
        {
            _loadingScreen.Hide();
        }

        private IEnumerator LoadScene(LoadSceneArgs loadSceneArgs)
        {
            if (SceneManager.GetActiveScene().name == loadSceneArgs.SceneName)
            {
                loadSceneArgs.OnLoadCallback?.Invoke();
                yield break;
            }

            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(loadSceneArgs.SceneName);

            while (!loadOperation.isDone)
            {
                _loadingScreen.SetProgressPercent(loadOperation.progress);
                yield return null;
            }

            loadSceneArgs.OnLoadCallback?.Invoke();
        }
        
    }
}
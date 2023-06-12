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

        public LoadSceneState(ICoroutineRunner coroutineRunner
            , IUIFactory uiFactory)
        {
            _coroutineRunner = coroutineRunner;
            _uiFactory = uiFactory;
        }

        public void Enter(LoadSceneArgs payload)
        {
            _coroutineRunner.StartCoroutine(LoadScene(payload));
        }

        public void Exit()
        {
        }

        private IEnumerator LoadScene(LoadSceneArgs loadSceneArgs)
        {
            LoadingScreen loadingScreen = _uiFactory.GetLoadingScreen();
            loadingScreen.Show();
            
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(loadSceneArgs.SceneName);

            while (!loadOperation.isDone)
            {
                loadingScreen.SetProgressPercent(loadOperation.progress);
                yield return null;
            }
            
            loadingScreen.Hide();
            loadSceneArgs.OnLoadCallback?.Invoke();

        }
    }
}
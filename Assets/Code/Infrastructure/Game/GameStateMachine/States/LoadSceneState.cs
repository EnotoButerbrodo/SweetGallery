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
            Debug.Log("LoadingExit");
        }

        private IEnumerator LoadScene(LoadSceneArgs loadSceneArgs)
        {
            if (SceneManager.GetActiveScene().name == loadSceneArgs.SceneName)
            {
                loadSceneArgs.OnLoadCallback?.Invoke();
                yield break;
            }
            
            Debug.Log("StartLoading " + loadSceneArgs.SceneName);

            var loadingScreen = _uiFactory.GetLoadingScreen();
            loadingScreen.Show();
            
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(loadSceneArgs.SceneName);
            loadOperation.allowSceneActivation = false;
            
            while (loadOperation.progress < 0.9f)
            {
                loadingScreen.SetProgressPercent(loadOperation.progress);
                yield return null;
            }

            yield return new WaitForSeconds(2f);
            

            _uiFactory.GetLoadingScreen().Hide();
            Debug.Log("StopLoading2 " + loadSceneArgs.SceneName);
            
            loadingScreen.Hide();
            loadOperation.allowSceneActivation = true;
            
            loadSceneArgs.OnLoadCallback?.Invoke();
        }
        
    }
}
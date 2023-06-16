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
            _coroutineRunner.StartCoroutine(LoadScene(payload));
        }

        public void Exit()
        {
   
            Debug.Log("LoadingExitAndHide");
        }

        private IEnumerator LoadScene(LoadSceneArgs loadSceneArgs)
        {
            if (SceneManager.GetActiveScene().name == loadSceneArgs.SceneName)
            {
                loadSceneArgs.OnLoadCallback?.Invoke();
                yield break; 
            }
            
            _loadingScreen.SetProgressPercent(0);
            _loadingScreen.Show();
            
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(loadSceneArgs.SceneName);
            loadOperation.allowSceneActivation = false;
            for (float time = 0; time <= 2; time += Time.deltaTime)
            {
                _loadingScreen.SetProgressPercent(time/2);
                yield return null;
            }

            while (loadOperation.isDone)
            {
                yield return null;
            }

            loadOperation.allowSceneActivation = true;
            
            yield return new WaitForSeconds(0.25f);
            
            _loadingScreen.Hide();
            
            loadSceneArgs.OnLoadCallback?.Invoke();




        }
        
    }
}
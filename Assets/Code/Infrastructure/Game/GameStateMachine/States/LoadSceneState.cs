using System.Collections;
using Code.Services;
using Code.Services.UIService;
using EnotoButerbrodo.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public sealed class LoadSceneState : IPayloadedState<LoadSceneArgs>
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IUIFactory _uiFactory;

        private readonly LoadingScreen _loadingScreen;

        private const float FakeLoadingTime = 2.5f;
        private const float PostLoadDelay = 0.25f;

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
        }
        

        private IEnumerator LoadScene(LoadSceneArgs loadSceneArgs)
        {
            if (SceneManager.GetActiveScene().name == loadSceneArgs.SceneName)
            {
                loadSceneArgs.OnSceneChanged?.Invoke();
                yield break; 
            }
            
            _loadingScreen.SetProgressPercent(0);
            _loadingScreen.Show();
            
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(loadSceneArgs.SceneName);
            loadOperation.allowSceneActivation = false;
            
            for (float time = 0; time <= FakeLoadingTime; time += Time.deltaTime)
            {
                _loadingScreen.SetProgressPercent(time/FakeLoadingTime);
                
                if (loadOperation.progress >= 0.89)
                {
                    loadOperation.allowSceneActivation = true;
                    loadSceneArgs.OnSceneChanged?.Invoke();
                }
                
                yield return null;
            }
            _loadingScreen.SetProgressPercent(1);
            yield return new WaitForSeconds(PostLoadDelay);

            _loadingScreen.Hide();
            loadSceneArgs.OnLoadComplete?.Invoke();
            
            
        }
        
    }
}
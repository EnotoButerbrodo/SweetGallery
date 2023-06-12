using System.Collections;
using Code.Services;
using EnotoButerbrodo.StateMachine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public class LoadSceneState : IPayloadedState<LoadSceneArgs>
    {
        private ICoroutineRunner _coroutineRunner;

        public LoadSceneState(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
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
            var loadOperation = SceneManager.LoadSceneAsync(loadSceneArgs.SceneName);

            while (!loadOperation.isDone)
            {
                yield return null;
            }
            
            loadSceneArgs.OnLoadCallback?.Invoke();
            
        }
    }
}
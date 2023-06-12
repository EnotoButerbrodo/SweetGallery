using System;

namespace Code.Infrastructure
{
    public class LoadSceneArgs
    {
        public readonly string SceneName;
        public readonly Action OnLoadCallback;
        
        public LoadSceneArgs(string sceneName, Action onLoadCallback = null)
        {
            SceneName = sceneName;
            OnLoadCallback = onLoadCallback;
        }
    }
}
using System;

namespace Code.Infrastructure
{
    public class LoadSceneArgs
    {
        public readonly string SceneName;
        public readonly Action OnSceneChanged;
        public readonly Action OnLoadComplete;
        
        public LoadSceneArgs(string sceneName
            , Action onSceneChanged = null
            , Action onLoadComplete = null)
        {
            SceneName = sceneName;
            OnSceneChanged = onSceneChanged;
            OnLoadComplete = onLoadComplete;
        }
    }
}
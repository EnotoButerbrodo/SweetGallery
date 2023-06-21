using UnityEngine;

namespace Code.UI
{
    public class ImageLoadingArgs
    {
        public ImageLoadingArgs(IImageHolder targetHolder
            , Coroutine loadingCoroutine)
        {
            _targetHolder = targetHolder;
            _loadingCoroutine = loadingCoroutine;
        }

        public IImageHolder _targetHolder;
        public Coroutine _loadingCoroutine;
    }
}
using UnityEngine;

namespace Code.Services.UIService
{
    public class Screen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private bool _hideInAwake = true;

        private void Awake()
        {
            if(_hideInAwake)
                Hide();
        }

        public void Show()
        {
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.alpha = 1f;
        }

        public void Hide()
        {
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = 0f;
        }
    }
}
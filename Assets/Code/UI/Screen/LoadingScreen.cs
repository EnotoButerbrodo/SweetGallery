using Code.UI.UIElements;
using TMPro;
using UnityEngine;

namespace Code.Services.UIService
{
    public class LoadingScreen : Screen
    {
        [SerializeField] private TextMeshProUGUI _loadPercentText;
        [SerializeField] private SimpleProgressBar _loadProgressBar;
        
        public void SetProgressPercent(float percent)
        {
            SetProgressText(percent);
            SetProgressBarFill(percent);
        }

        private void SetProgressText(float percent)
        {
            _loadPercentText.text = Mathf.RoundToInt(percent * 100).ToString();
        }

        private void SetProgressBarFill(float percent)
        {
            _loadProgressBar.SetValue(percent);
        }
    }
}
using Code.UI.UIElements;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

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
            _loadPercentText.text = System.MathF.Round(percent, 1).ToString();
        }

        private void SetProgressBarFill(float percent)
        {
            _loadProgressBar.SetValue(percent);
        }
    }
}
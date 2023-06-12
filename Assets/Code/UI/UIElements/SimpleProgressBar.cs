using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.UIElements
{
    public class SimpleProgressBar : MonoBehaviour, IProgressBar
    {
        [SerializeField] private Image _background;
        [SerializeField] private Image _foreground;

        [SerializeField] private float _currentValue;
        [SerializeField] private float _maxValue;

        private void Awake()
        {
            SetValue(_currentValue);
        }

        public void SetMaxValue(float value)
        {
            _maxValue = value;

            ClampCurrentValue();
            UpdateProgressBar();
        }

        public void SetValue(float value)
        {
            _currentValue = value;
            
            ClampCurrentValue();
            UpdateProgressBar();
        }

        private void ClampCurrentValue()
        {
            if (_currentValue > _maxValue)
                _currentValue = _maxValue;
        }

        private void UpdateProgressBar()
        {
            float fillPercent = _currentValue / _maxValue;
            _foreground.fillAmount = fillPercent;
        }
    }
}
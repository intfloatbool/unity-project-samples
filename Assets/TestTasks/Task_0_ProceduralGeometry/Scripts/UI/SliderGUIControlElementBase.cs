using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.UI
{
    public abstract class SliderGUIControlElementBase : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _currentValue;
        [SerializeField] protected Slider _slider;
        
        protected readonly string FORMAT_SPECIFIER = "F1"; 
        
        protected virtual void Awake()
        {
            _slider.onValueChanged.AddListener(HandleOnValueChangedInternal);
        }

        protected virtual void Start()
        {
            HandleOnValueChangedInternal(_slider.value);
        }

        private void OnDestroy()
        {
            if(_slider)
                _slider.onValueChanged.RemoveListener(HandleOnValueChangedInternal);
        }

        private void HandleOnValueChangedInternal(float value)
        {
            UpdateText();
            HandleOnValueChanged(value);
        }

        protected abstract void HandleOnValueChanged(float value);

        protected void UpdateText()
        {
            _currentValue.text = _slider.value.ToString(FORMAT_SPECIFIER);
        }
    }
}
using System;
using TestTasks.Task_2_OOP_And_Design.Scripts.Modules;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.UI
{
    public class ModuleUIElement : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Graphic _bgGraphic;
        [SerializeField] private TextMeshProUGUI _labelText;

        public ModuleBase HoldedModule { get; private set; } = new NullModule();
        public event Action<ModuleUIElement> OnClicked; 
        
        public bool IsEquipped { get; set; }

        private void Awake()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDestroy()
        {
            if(_button)
                _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            OnClicked?.Invoke(this);
        }

        public void Init(ModuleBase module, string moduleName, Color bgColor)
        {
            HoldedModule = module;
            SetText(moduleName);
            _bgGraphic.color = bgColor;
        }

        public void SetText(string text)
        {
            _labelText.text = text;
        }
    }
}
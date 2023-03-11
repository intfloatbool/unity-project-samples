using UnityEngine;
using UnityEngine.UI;

namespace Common.Scripts
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonHandlerBase : MonoBehaviour
    {
        protected Button _button;

        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(OnClick);
        }

        protected virtual void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        protected abstract void OnClick();
    }
}
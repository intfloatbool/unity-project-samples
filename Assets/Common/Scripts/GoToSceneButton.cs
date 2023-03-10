using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Common.Scripts
{
    [RequireComponent(typeof(Button))]
    public class GoToSceneButton : MonoBehaviour
    {
        [SerializeField] private string _sceneName;

        private UniTask _currentLoadingTask;
        
        private Button _btn;

        private void Awake()
        {
            _btn = GetComponent<Button>();
            
            _btn.onClick.AddListener(OnButtonClicked);
        }

        private void OnDestroy()
        {
            _btn.onClick.RemoveListener(OnButtonClicked); 
        }

        private void OnButtonClicked()
        {
            TryLoadScene().Forget();
        }

        private async UniTaskVoid TryLoadScene()
        {
            if(_currentLoadingTask.Status == UniTaskStatus.Pending)
                return;
            try
            {
                _currentLoadingTask = SceneManager.LoadSceneAsync(_sceneName).ToUniTask();
                await _currentLoadingTask;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[{GetType().Name}] some exception occured: {ex}");
            }
            
        }
    }
}

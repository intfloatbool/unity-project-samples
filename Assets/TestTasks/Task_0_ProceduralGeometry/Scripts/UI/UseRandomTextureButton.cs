using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class UseRandomTextureButton : MonoBehaviour
    {
        [SerializeField] private string _textureApiUrl;
        [SerializeField] private MeshRenderer _meshRenderer;
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");
        private UniTask _currentTask;

        private void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            if(_currentTask.Status == UniTaskStatus.Pending)
                return;
            TryUpdateTextureAsync().Forget();
        }

        private async UniTaskVoid TryUpdateTextureAsync()
        {
            if(!_meshRenderer)
                return;
            
            var www = UnityWebRequestTexture.GetTexture(_textureApiUrl);
            _currentTask = www.SendWebRequest().ToUniTask();
            await _currentTask;

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"[{GetType().Name}] error! {www.error}");
                return;
            }
            
            Texture texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            
            _meshRenderer.material.SetTexture(MainTex, texture);

            _currentTask = default;
        }
    }
}
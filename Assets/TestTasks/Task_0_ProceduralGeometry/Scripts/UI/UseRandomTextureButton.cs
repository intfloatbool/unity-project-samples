using Common.Scripts;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.UI
{
    public class UseRandomTextureButton : ButtonHandlerBase
    {
        [SerializeField] private string _textureApiUrl;
        [SerializeField] private MeshRenderer _meshRenderer;
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");
        private UniTask _currentTask;

        protected override void OnClick()
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
using System;
using Common.Scripts;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TestTasks.Task_1_Algorithms_And_DataStructures.Scripts.BusinessLogic;
using TMPro;
using UnityEngine;

namespace TestTasks.Task_1_Algorithms_And_DataStructures.Scripts
{
    public class SubwayStationView : MonoBehaviour
    {
        [SerializeField] private string _label;
        public string Label => _label;

        [SerializeField] private EStationColorType _colorType;
        private TextMeshPro _textMesh;
        public EStationColorType ColorType => _colorType;
        
        
        public event Action<SubwayStationView> OnClick;

        private UniTask _currentHighlightTask;

        private void Awake()
        {
            var clickableCollider = GetComponent<ClickableCollider>();
            clickableCollider.OnClick += (cc) =>
            {
                OnClick?.Invoke(this);
            };
            
            //shit code just for dynamic view
            var meshRend = GetComponentInChildren<MeshRenderer>();
            if (meshRend)
            {
                var color = Color.magenta;

                switch (_colorType)
                {
                    case EStationColorType.RED:
                    {
                        color = Color.red;
                        break;
                    }
                    case EStationColorType.GREEN:
                    {
                        color = Color.green;
                        break;
                    }
                    case EStationColorType.BLUE:
                    {
                        color = Color.blue;
                        break;
                    }
                    case EStationColorType.BLACK:
                    {
                        color = Color.black;
                        break;
                    }
                }
                
                meshRend.material.SetColor("_Color", color);
            }

            _textMesh = GetComponentInChildren<TextMeshPro>();
            if (_textMesh)
            {
                _textMesh.text = _label;
            }

            gameObject.name = "STATION_" + ToString();

        }

        public void Highlight()
        {
            if(_currentHighlightTask.Status == UniTaskStatus.Pending)
                return;
            AnimationHighlight().Forget();
        }

        private async UniTaskVoid AnimationHighlight()
        {
            _currentHighlightTask = DOTween.Sequence()
                .Append(transform.DOScale(Vector3.one * 2f, 0.5f))
                .Append(_textMesh.DOColor(Color.yellow, 1f))
                .Append(_textMesh.DOColor(Color.white, 1f))
                .Append(transform.DOScale(Vector3.one * 1f, 0.5f))
                .Play().ToUniTask(cancellationToken: gameObject.GetCancellationTokenOnDestroy());
                
            await _currentHighlightTask;

            _currentHighlightTask = default;
        }

        public override string ToString()
        {
            return $"{_colorType}_{_label}";
        }
    }
}
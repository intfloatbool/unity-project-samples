using System;
using Common.Scripts;
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
        public EStationColorType ColorType => _colorType;
        
        
        public event Action<SubwayStationView> OnClick;

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

            var textMesh = GetComponentInChildren<TextMeshPro>();
            if (textMesh)
            {
                textMesh.text = _label;
            }

            gameObject.name = "STATION_" + ToString();

        }

        public override string ToString()
        {
            return $"{_colorType}_{_label}";
        }
    }
}
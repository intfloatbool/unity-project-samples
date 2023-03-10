using System;
using TestTasks.Task_0_ProceduralGeometry.Scripts.MeshCreators;
using UnityEngine;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts
{
    public class FlagCloth : MonoBehaviour
    {
        [Range(1, 100)]
        [SerializeField] private int _initialWidth = 4;
        
        [Range(1, 100)]
        [SerializeField] private int _initialHeight = 2;
        
        [Space]
        [SerializeField] private ProceduralMeshView _meshView;
        
        private int _width;
        public int Width
        {
            get => _width;
            set
            {
                if (value != _width)
                {
                    _width = value;
                    OnWidthChanged?.Invoke(_width);
                }
            }
        }

        private int _height;
        public int Height
        {
            get => _height;
            set
            {
                if (value != _height)
                {
                    _height = value;
                    OnHeightChanged?.Invoke(_height);
                }
            }
        }

        private IMeshCreator _meshCreator;


        public event Action<int> OnWidthChanged; 
        public event Action<int> OnHeightChanged;

        private void Awake()
        {
            OnWidthChanged += HandleOnWidthChanged;
            OnHeightChanged += HandleOnHeightChanged;
        }

        private void OnDestroy()
        {
            OnWidthChanged -= HandleOnWidthChanged;
            OnHeightChanged -= HandleOnHeightChanged;
        }
        
        private void HandleOnWidthChanged(int width)
        {
            RegenerateMesh();
        }

        private void HandleOnHeightChanged(int height)
        {
            RegenerateMesh();
        }
        private void RegenerateMesh()
        {
            _meshCreator = new PlaneMeshCreator(Width, Height);
            _meshView.MeshFilter.mesh = _meshCreator.Create();
        }
       
   
    }
}
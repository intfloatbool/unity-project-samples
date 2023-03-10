using System;
using TestTasks.Task_0_ProceduralGeometry.Scripts.MeshCreators;
using UnityEngine;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    public class ProceduralMeshView : MonoBehaviour
    {
        private MeshFilter _meshFilter;
        public MeshFilter MeshFilter => _meshFilter;
        
        private MeshRenderer _meshRenderer;
        public MeshRenderer MeshRenderer => _meshRenderer;

        private void Awake()
        {
            _meshFilter = GetComponent<MeshFilter>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }
    }
}
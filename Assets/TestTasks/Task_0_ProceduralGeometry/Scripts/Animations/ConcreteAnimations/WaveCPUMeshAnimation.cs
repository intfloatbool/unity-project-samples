using System.Collections.Generic;
using UnityEngine;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.Animations.ConcreteAnimations
{
    public class WaveCPUMeshAnimation : MeshAnimationBase
    {
        public float Speed { get; set; }
        public float Frequency { get; set; }
        public float Amplitude { get; set; }
        
        private Mesh _lastMesh;
        private List<Vector3> _vertexBufferA;
        private List<Vector3> _vertexBufferB;
        
        
        public WaveCPUMeshAnimation(MeshFilter meshFilter, MeshRenderer meshRenderer) : base(meshFilter, meshRenderer)
        {
        }

        public override void OnStart()
        {
            base.OnStart();

            UpdateBuffers();
        }

        private void UpdateBuffers()
        {
            var vertices = _meshFilter.mesh.vertices;
            _vertexBufferA = new List<Vector3>(vertices);
            _vertexBufferB = new List<Vector3>(vertices);
        }

        public override void OnTick()
        {
            UpdateVertex();
        }

        private void UpdateVertex()
        {
            var mesh = _meshFilter.mesh;
            if (mesh != _lastMesh)
            {
                UpdateBuffers();
                _lastMesh = mesh;
            }
            
            for (int i = 0; i < _vertexBufferA.Count; i++)
            {
                var vertex = _vertexBufferA[i];
                vertex.y += Mathf.Cos((vertex.x + Time.time * Speed) * Frequency) * Amplitude * (vertex.x - 5);
                _vertexBufferB[i] = vertex;
                
            }
            
            mesh.SetVertices(_vertexBufferB);
        }
    }
}
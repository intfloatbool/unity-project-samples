using System.Collections.Generic;
using UnityEngine;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.Animations.ConcreteAnimations
{
    public class TextureUvCPUMeshAnimation : MeshAnimationBase
    {
        public float ScrollSpeed { get; set; }

        private List<Vector2> _uvBufferA;
        private List<Vector2> _uvBufferB;
        private Mesh _lastMesh;
        
        public TextureUvCPUMeshAnimation(MeshFilter meshFilter, MeshRenderer meshRenderer) : base(meshFilter, meshRenderer)
        {
            
        }

        public override void OnStart()
        {
            base.OnStart();
            
            UpdateBuffers();
        }

        private void UpdateBuffers()
        {
            var mesh = _meshFilter.mesh;
            _uvBufferA = new List<Vector2>(mesh.uv);
            _uvBufferB = new List<Vector2>(mesh.uv);
        }

        public override void OnTick()
        {
            base.OnTick();

            UpdateUVs();
        }

        private void UpdateUVs()
        {
            var mesh = _meshFilter.mesh;
            if (mesh != _lastMesh)
            {
                UpdateBuffers();
                _lastMesh = mesh;
            }
            
            var step = ScrollSpeed * Time.deltaTime;
            for (int i = 0; i < _uvBufferA.Count; i++)
            {
                var uv = _uvBufferB[i];
                uv.x -= step;

                _uvBufferB[i] = uv;
            }

            mesh.SetUVs(0, _uvBufferB);
        }
    }
}
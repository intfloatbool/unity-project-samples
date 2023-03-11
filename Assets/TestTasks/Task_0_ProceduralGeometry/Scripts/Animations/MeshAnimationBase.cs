using UnityEngine;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.Animations
{
    public abstract class MeshAnimationBase
    {
        protected MeshFilter _meshFilter;
        protected MeshRenderer _meshRenderer;

        public MeshAnimationBase(MeshFilter meshFilter, MeshRenderer meshRenderer)
        {
            _meshFilter = meshFilter;
            _meshRenderer = meshRenderer;
        }

        public virtual void OnStart() {}
        public virtual void OnStop() {}
        public virtual void OnTick() {}
    }
}
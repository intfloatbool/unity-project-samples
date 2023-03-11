using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.Animations
{
    public class MacroMeshAnimation : MeshAnimationBase
    {
        private readonly List<MeshAnimationBase> _meshAnimations;
        public IReadOnlyList<MeshAnimationBase> MeshAnimations => _meshAnimations;
        public MacroMeshAnimation(MeshFilter meshFilter, MeshRenderer meshRenderer, params MeshAnimationBase[] meshAnimations) : base(meshFilter, meshRenderer)
        {
            _meshAnimations = new List<MeshAnimationBase>(meshAnimations);
        }

        public override void OnStart()
        {
            base.OnStart();
            
            foreach(var meshAnim in _meshAnimations)
                meshAnim.OnStart();
        }

        public override void OnStop()
        {
            foreach(var meshAnim in _meshAnimations)
                meshAnim.OnStop();
        }

        public override void OnTick()
        {
            foreach(var meshAnim in _meshAnimations)
                meshAnim.OnTick();
        }
    }
}
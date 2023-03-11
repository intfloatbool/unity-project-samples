﻿using Common.Scripts;
using TestTasks.Task_0_ProceduralGeometry.Scripts.Animations;
using TestTasks.Task_0_ProceduralGeometry.Scripts.Animations.ConcreteAnimations;
using UnityEngine;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.UI
{
    public class UseCPUAnimationButton : ButtonHandlerBase
    {
        [SerializeField] private MeshAnimationView _animationView;
        
        protected override void OnClick()
        {
            var meshFilter = _animationView.MeshFilter;
            var meshRenderer = _animationView.MeshRenderer;
            _animationView.SetAnimation(new MacroMeshAnimation(meshFilter, meshRenderer, 
                new WaveCPUMeshAnimation(meshFilter, meshRenderer)
                {
                    Speed = 3, Frequency = 1, Amplitude = 0.1f
                },
                new TextureUvCPUMeshAnimation(meshFilter, meshRenderer)
                {
                    ScrollSpeed = 5f
                }
                ));
        }
    }
}
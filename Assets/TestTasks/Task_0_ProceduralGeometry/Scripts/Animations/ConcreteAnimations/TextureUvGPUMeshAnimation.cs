using UnityEngine;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.Animations.ConcreteAnimations
{
    public class TextureUvGPUMeshAnimation : MeshAnimationBase
    {
        private readonly Material _currentMaterial;
        private static readonly int UVScrollSpeed = Shader.PropertyToID("_UVScrollSpeed");
        public float ScrollSpeed { get; set; }
        
        
        public TextureUvGPUMeshAnimation(MeshFilter meshFilter, MeshRenderer meshRenderer) : base(meshFilter, meshRenderer)
        {
            _currentMaterial = meshRenderer.material;
        }

        public override void OnStart()
        {
            base.OnStart();
            
            _currentMaterial.SetInt("_IsAnimatedUV", 1);
        }

        public override void OnStop()
        {
            base.OnStop();
            
            _currentMaterial.SetInt("_IsAnimatedUV", 0);
            
            _currentMaterial.SetFloat(UVScrollSpeed, 0);
        }


        public override void OnTick()
        {
            base.OnTick();

            PassProperties();
        }

        private void PassProperties()
        {
            var step = ScrollSpeed * Time.deltaTime;
            var currentOffsetX = _currentMaterial.GetFloat(UVScrollSpeed);
            _currentMaterial.SetFloat(UVScrollSpeed, currentOffsetX - step);
        }
        
    }
}
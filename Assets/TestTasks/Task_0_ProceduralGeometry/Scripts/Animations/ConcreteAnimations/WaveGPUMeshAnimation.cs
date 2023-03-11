using UnityEngine;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.Animations.ConcreteAnimations
{
    public class WaveGPUMeshAnimation : MeshAnimationBase
    {
        
        public float Speed { get; set; }
        public float Frequency { get; set; }
        public float Amplitude { get; set; }

        private readonly Material _currentMaterial;
        private static readonly int SpeedShaderProp = Shader.PropertyToID("_Speed");
        private static readonly int FrequencyShaderProp = Shader.PropertyToID("_Frequency");
        private static readonly int AmplitudeShaderProp = Shader.PropertyToID("_Amplitude");


        public WaveGPUMeshAnimation(MeshFilter meshFilter, MeshRenderer meshRenderer) : base(meshFilter, meshRenderer)
        {
            _currentMaterial = meshRenderer.material;
        }

        public override void OnStart()
        {
            base.OnStart();
            
            _currentMaterial.SetInt("_IsAnimatedVertex", 1);
        }

        public override void OnStop()
        {
            base.OnStop();
            
            _currentMaterial.SetInt("_IsAnimatedVertex", 0);
        }

        public override void OnTick()
        {
            PassProperties();
        }

        private void PassProperties()
        {
            _currentMaterial.SetFloat(SpeedShaderProp, Speed);
            _currentMaterial.SetFloat(FrequencyShaderProp, Frequency);
            _currentMaterial.SetFloat(AmplitudeShaderProp, Amplitude);
        }

      
    }
}
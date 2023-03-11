using UnityEngine;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.Animations
{
    public class MeshAnimationView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        public MeshRenderer MeshRenderer => _meshRenderer;
        [SerializeField] private MeshFilter _meshFilter;
        public MeshFilter MeshFilter => _meshFilter;

        private MeshAnimationBase _currentMeshAnimation = new NullMeshAnimation();
        public MeshAnimationBase CurrentMeshAnimation => _currentMeshAnimation;

        public void SetAnimation(MeshAnimationBase meshAnimation)
        {
            _currentMeshAnimation?.OnStop();
            _currentMeshAnimation = meshAnimation;
            _currentMeshAnimation.OnStart();
        }

        private void Update()
        {
            _currentMeshAnimation?.OnTick();
        }
    }
}
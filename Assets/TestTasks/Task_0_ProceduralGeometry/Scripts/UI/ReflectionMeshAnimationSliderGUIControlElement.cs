using TestTasks.Task_0_ProceduralGeometry.Scripts.Animations;
using UnityEngine;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.UI
{
    public class ReflectionMeshAnimationSliderGUIControlElement : SliderGUIControlElementBase
    {
        [SerializeField] private string _propertyName;
        [SerializeField] private MeshAnimationView _target;
        
        protected override void HandleOnValueChanged(float value)
        {
            var currentAnimation = _target.CurrentMeshAnimation;
            if (currentAnimation is MacroMeshAnimation macroMeshAnimation)
            {
                foreach (var meshAnimation in macroMeshAnimation.MeshAnimations)
                {
                    TryApplyProperty(meshAnimation, value);
                }
            }
            else
            {
                TryApplyProperty(currentAnimation, value);
            }
        }

        private void TryApplyProperty(object target, float value)
        {
            var type = target.GetType();
            var field = type.GetField(_propertyName);

            if (field != null)
            {
                if (field.FieldType == typeof(int))
                {
                    field.SetValue(target, Mathf.RoundToInt(value));
                }
                    
                if (field.FieldType == typeof(float))
                {
                    field.SetValue(target, value);
                }
                    
            }
                
            var property = type.GetProperty(_propertyName);

            if (property != null)
            {
                if (property.PropertyType == typeof(int))
                {
                    property.SetValue(target, Mathf.RoundToInt(value));
                }
                    
                if (property.PropertyType == typeof(float))
                {
                    property.SetValue(target, value);
                }
            }
        }
    }
}
using System;
using System.Reflection;
using UnityEngine;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.UI
{
    public class ReflectionSliderGUIControlElement : SliderGUIControlElementBase
    {
        [SerializeField] private string _propertyName;
        [SerializeField] private GameObject _target;

        private Component[] _cachedComponents;
        
        protected override void HandleOnValueChanged(float value)
        {
            if (_cachedComponents == null)
            {
                _cachedComponents = _target.GetComponents<Component>();
            }

            foreach (var component in _cachedComponents)
            {
                var componentType = component.GetType();
                var field = componentType.GetField(_propertyName);

                if (field != null)
                {
                    if (field.FieldType == typeof(int))
                    {
                        field.SetValue(component, Mathf.RoundToInt(value));
                    }
                    
                    if (field.FieldType == typeof(float))
                    {
                        field.SetValue(component, value);
                    }
                    
                }
                
                var property = componentType.GetProperty(_propertyName);

                if (property != null)
                {
                    if (property.PropertyType == typeof(int))
                    {
                        property.SetValue(component, Mathf.RoundToInt(value));
                    }
                    
                    if (property.PropertyType == typeof(float))
                    {
                        property.SetValue(component, value);
                    }
                }

            }
        }
    }
}
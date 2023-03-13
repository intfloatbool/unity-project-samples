using System.Collections.Generic;
using TestTasks.Task_2_OOP_And_Design.Scripts.Modules;
using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.UI
{
    public class ModulesUIElementsClicksHandler : MonoBehaviour
    {
        [SerializeField] private Transform _possibleModulesRoot;
        [SerializeField] private Transform _weaponModulesRoot;
        [SerializeField] private Transform _commonModulesRoot;

        [Space]
        [SerializeField] private ModulesUIElementsCreator _modulesUIElementsCreator;

        private IEnumerable<ModuleUIElement> _lastElements;
        private void Awake()
        {
            _modulesUIElementsCreator.OnModuleRepresentationsCreated += HandleOnModuleRepresentationsCreated;
        }

        private void OnDestroy()
        {
            if(_modulesUIElementsCreator)
                _modulesUIElementsCreator.OnModuleRepresentationsCreated -= HandleOnModuleRepresentationsCreated;
        }

        private void HandleOnModuleRepresentationsCreated(IReadOnlyList<ModuleUIElement> elementsCollection)
        {
            if (_lastElements != null)
            {
                foreach (var element in _lastElements)
                {
                    if(element)
                        element.OnClicked -= HandleOnModuleUIElementClicked;
                }
            }

            foreach (var element in elementsCollection)
            {
                if(element)
                    element.OnClicked += HandleOnModuleUIElementClicked;
            }
            
            _lastElements = elementsCollection;
        }

        private void HandleOnModuleUIElementClicked(ModuleUIElement element)
        {
            var vehicleStats = _modulesUIElementsCreator.VehicleStats;
            var holdedModule = element.HoldedModule;
            if (element.IsEquipped)
            {
                if (vehicleStats.TryRemoveModule(holdedModule))
                {
                    SetElementParent(element, _possibleModulesRoot);
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (vehicleStats.TryAddModule(holdedModule))
                {
                    var isWeapon = holdedModule is WeaponModule;
                    var parent = isWeapon ? _weaponModulesRoot : _commonModulesRoot;
                    SetElementParent(element, parent );
                }
                else
                {
                    return;
                }
            }

            element.IsEquipped = !element.IsEquipped;
        }

        private void SetElementParent(ModuleUIElement element, Transform parent)
        {
            element.transform.SetParent(parent);
        }
    }
}
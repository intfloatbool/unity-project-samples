using System;
using System.Collections.Generic;
using TestTasks.Task_2_OOP_And_Design.Scripts.Constants;
using TestTasks.Task_2_OOP_And_Design.Scripts.Model;
using TestTasks.Task_2_OOP_And_Design.Scripts.Modules;
using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;
using TMPro;
using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.UI
{
    public class ModulesUIElementsCreator : MonoBehaviour
    {

        [SerializeField] private Transform _root;
        [SerializeField] private ModuleUIElement _moduleUIPrefab;
        
        [Space]
        [SerializeField] private TextMeshProUGUI _totalStatsInfoText;
        
        private List<ModuleUIElement> _currentModuleRepresentationCollection = new List<ModuleUIElement>(10);

        public Action<IReadOnlyList<ModuleUIElement>> OnModuleRepresentationsCreated;
        private IPossibleModulesProvider _modulesProvider;

        public VehicleStats VehicleStats { get; private set; } 

        public void Init(VehicleStats vehicleStats, IPossibleModulesProvider possibleModulesProvider)
        {
            VehicleStats = vehicleStats;
            _modulesProvider = possibleModulesProvider;

            UpdateTotalStatsText();
            
            VehicleStats.OnStatsChanged += HandleOnVehicleStatsChanged;
        }

        private void OnDestroy()
        {
            if(VehicleStats != null)
                VehicleStats.OnStatsChanged -= HandleOnVehicleStatsChanged;
                
        }

        private void HandleOnVehicleStatsChanged()
        {
            UpdateTotalStatsText();
        }

        private void UpdateTotalStatsText()
        {
            _totalStatsInfoText.text = VehicleStats.ToString();
        }

        public void RecreateModuleRepresentations()
        {
            Clear();

            var moduleCollection = _modulesProvider.ProvidePossibleModules();

            foreach (var module in moduleCollection)
            {
                var uiElement = Instantiate(_moduleUIPrefab, _root);

                var moduleName = module.ToString();
                var moduleColor = GameConstants.MISSING_COLOR;

                if (module is WeaponModule weaponModule)
                {
                    moduleColor = new Color(0.7f, 0.4f, 0.4f, 1f);
                }
                else if (module is StatsAffectorModuleBase affectorModule)
                {
                    moduleColor = new Color(0.4f, 0.7f, 0.4f, 1f);
                }
                
                uiElement.Init(module, moduleName, moduleColor);
                
                _currentModuleRepresentationCollection.Add(uiElement);
            }
            
            OnModuleRepresentationsCreated?.Invoke(_currentModuleRepresentationCollection);
        }

        private void Clear()
        {
            _currentModuleRepresentationCollection.ForEach(mp =>
            {
                if(mp) Destroy(mp.gameObject);
            });
            
            _currentModuleRepresentationCollection.Clear();
        }

        
    }
}
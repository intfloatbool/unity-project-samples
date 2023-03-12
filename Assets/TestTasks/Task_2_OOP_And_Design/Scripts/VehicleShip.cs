using System;
using System.Collections.Generic;
using TestTasks.Task_2_OOP_And_Design.Scripts.Modules;
using TestTasks.Task_2_OOP_And_Design.Scripts.Targeting;
using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;
using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts
{
    public class VehicleShip : MonoBehaviour, ITargetable, IDamageable, IDestroyable
    {
        public VehicleStats CurrentVehicleStats { get; private set; }
        public event Action OnDestroyed;
        public bool IsDestroyed { get; private set; } = false;

        private List<WeaponModule> _weaponModulesCollection;
        private List<StatsAffectorModuleBase> _statsAffectorsModulesCollection;
        private List<ModuleBase> _allModules;

        private bool _isDestroyed;

        public void Init(VehicleStats vehicleStats, IEnumerable<WeaponModule> weaponModules, IEnumerable<StatsAffectorModuleBase> statsModules)
        {
            CurrentVehicleStats = vehicleStats.Clone();

            _weaponModulesCollection = new List<WeaponModule>(weaponModules);
            _statsAffectorsModulesCollection = new List<StatsAffectorModuleBase>(statsModules);

            _allModules = new List<ModuleBase>(_statsAffectorsModulesCollection.Count + _weaponModulesCollection.Count);
            
            _allModules.AddRange(_weaponModulesCollection);
            _allModules.AddRange(_statsAffectorsModulesCollection);

        }

        private void Update()
        {
            HandleAllModulesLoop();
        }
        
        private void HandleAllModulesLoop()
        {
            foreach(var module in _allModules)
                module.OnFrame();
        }

        public Vector3? CurrentPosition => transform ? transform.position : null;
        public void ReceiveDamage(int damage)
        {
            if(IsDestroyed)
                return;
            
            CurrentVehicleStats.CurrentHp -= damage;
            if (CurrentVehicleStats.CurrentHp <= 0)
            {
                OnDestroyed?.Invoke();
                Destroy(gameObject);
            }
            CurrentVehicleStats.CurrentHp = Mathf.Clamp(CurrentVehicleStats.CurrentHp, 0, int.MaxValue);
        }

        private void OnDestroy()
        {
            IsDestroyed = true;
        }
    }
}
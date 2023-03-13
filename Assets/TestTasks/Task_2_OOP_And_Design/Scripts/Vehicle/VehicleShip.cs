using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TestTasks.Task_2_OOP_And_Design.Scripts.Modules;
using TestTasks.Task_2_OOP_And_Design.Scripts.Targeting;
using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle
{
    public class VehicleShip : MonoBehaviour, ITargetable, IDamageable, IDestroyable
    {

        [SerializeField] private Transform _weaponSource;
        [SerializeField] private VehicleStatsView _vehicleStatsView;
        
        private List<WeaponModule> _weaponModulesCollection = new();
        private List<StatsAffectorModuleBase> _statsAffectorsModulesCollection = new();
        private List<ModuleBase> _allModules = new();

        private bool _isDestroyed;
        private ITargetable _currentTargetable = new NullTargetable();

        public VehicleStats CurrentVehicleStats { get; private set; }
        public event Action OnDestroyed;
        public bool IsDestroyed { get; private set; } = false;
        public event Action OnInitialized;

        public void Init(VehicleStats vehicleStats)
        {
            CurrentVehicleStats = vehicleStats;

            _weaponModulesCollection = new List<WeaponModule>(vehicleStats.WeaponModules);
            _statsAffectorsModulesCollection = new List<StatsAffectorModuleBase>(vehicleStats.StatsModules);

            _allModules = new List<ModuleBase>(_statsAffectorsModulesCollection.Count + _weaponModulesCollection.Count);
            
            _allModules.AddRange(_weaponModulesCollection);
            _allModules.AddRange(_statsAffectorsModulesCollection);

            HandleShieldsRegenerationAsync().Forget();
            
            _vehicleStatsView.Init(CurrentVehicleStats);
            OnInitialized?.Invoke();
        }

        public void SetTarget(ITargetable targetable)
        {
            _currentTargetable = targetable;
        }

        private void Update()
        {
            HandleAllModulesLoop();
            HandleWeaponsLoop();
        }
        
        private void HandleAllModulesLoop()
        {
            foreach(var module in _allModules)
                module.OnFrame();
        }

        private void HandleWeaponsLoop()
        {
            foreach (var weapon in _weaponModulesCollection)
            {
                weapon.SetSourcePosition(_weaponSource ? _weaponSource.position : transform.position);
                weapon.SetTarget(_currentTargetable);
            }
        }

        private async UniTask HandleShieldsRegenerationAsync()
        {
            var cToken = gameObject.GetCancellationTokenOnDestroy();
            while (gameObject)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: cToken);
                CurrentVehicleStats.CurrentShield += CurrentVehicleStats.CurrentShieldRegenerationPerSecond;

                CurrentVehicleStats.CurrentShield =
                    Mathf.Clamp(CurrentVehicleStats.CurrentShield, 0, CurrentVehicleStats.MaxShield);
            }
        }

        public Vector3? CurrentPosition => transform ? transform.position : null;
        public void ReceiveDamage(int damage)
        {
            if(IsDestroyed)
                return;

            var remainDamageAfterShield = damage;
            if (CurrentVehicleStats.CurrentShield > 0)
            {
                var shieldBeforeDamage = CurrentVehicleStats.CurrentShield;
                CurrentVehicleStats.CurrentShield -= damage;
                CurrentVehicleStats.CurrentShield =
                    Mathf.Clamp(CurrentVehicleStats.CurrentShield, 0, CurrentVehicleStats.MaxShield);

                remainDamageAfterShield = Mathf.FloorToInt(shieldBeforeDamage - damage) <= 0 ? Mathf.FloorToInt(Mathf.Abs(shieldBeforeDamage - damage)) : 0;
            }
            
            if(remainDamageAfterShield <= 0)
                return;
            
            CurrentVehicleStats.CurrentHp -= remainDamageAfterShield;
            if (CurrentVehicleStats.CurrentHp <= 0)
            {
                OnDestroyed?.Invoke();
                Destroy(gameObject);
            }
            CurrentVehicleStats.CurrentHp = Mathf.Clamp(CurrentVehicleStats.CurrentHp, 0, int.MaxValue);
            
            /*Debug.Log($"[{gameObject.name}] receiveDamage: {damage} ! Hp remains: {CurrentVehicleStats.CurrentHp}");*/
        }

        private void OnDestroy()
        {
            IsDestroyed = true;
        }
    }
}
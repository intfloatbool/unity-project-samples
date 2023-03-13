using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTasks.Task_2_OOP_And_Design.Scripts.Modules;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle
{
    public class VehicleStats
    {
        private int _weaponsSlotsCount;

        public int WeaponSlotsCount
        {
            get => _weaponsSlotsCount;
            set
            {
                _weaponsSlotsCount = value;
                OnStatsChanged?.Invoke();
            }
        }
        
        private int _commonModulesSlotsCount;

        public int CommonModulesSlotsCount
        {
            get => _commonModulesSlotsCount;
            set
            {
                _commonModulesSlotsCount = value;
                OnStatsChanged?.Invoke();
            }
        }
        
        private int _baseHp;

        public int BaseHp
        {
            get => _baseHp;
            set
            {
                _baseHp = value;
                OnStatsChanged?.Invoke();
            }
        }
        
        private int _baseShield;

        public int BaseShield
        {
            get => _baseShield;
            set
            {
                _baseShield = value;
                OnStatsChanged?.Invoke();
            }
        }

        private int _maxHp;

        public int MaxHp
        {
            get => _maxHp;
            set
            {
                _maxHp = value;
                OnStatsChanged?.Invoke();
            }
        }

        private int _maxShield;

        public int MaxShield
        {
            get => _maxShield;
            set
            {
                _maxShield = value;
                OnStatsChanged?.Invoke();
            }
        }

        private int _currentHp;

        public int CurrentHp
        {
            get => _currentHp;
            set
            {
                _currentHp = value;
                OnStatsChanged?.Invoke();
            }
        }

        private float _currentShield;

        public float CurrentShield
        {
            get => _currentShield;
            set
            {
                _currentShield = value;
                OnStatsChanged?.Invoke();
            }
        }

        private float _baseShieldRegenerationPerSecond;

        public float BaseShieldRegenerationPerSecond
        {
            get => _baseShieldRegenerationPerSecond;
            set
            {
                _baseShieldRegenerationPerSecond = value;
                OnStatsChanged?.Invoke();
            }
        }

        private float _currentShieldRegenerationPerSecond;

        public float CurrentShieldRegenerationPerSecond
        {
            get => _currentShieldRegenerationPerSecond;
            set
            {
                _currentShieldRegenerationPerSecond = value;
                OnStatsChanged?.Invoke();
            }
        }

        public IReadOnlyList<WeaponModule> WeaponModules => _weaponModules;
        public IReadOnlyList<StatsAffectorModuleBase> StatsModules => _statsModules;

        public event Action OnStatsChanged; 

        private List<WeaponModule> _weaponModules = new List<WeaponModule>(3);
        private List<StatsAffectorModuleBase> _statsModules = new List<StatsAffectorModuleBase>(3);
        

        public VehicleStats Clone()
        {
            return MemberwiseClone() as VehicleStats;
        }

        public bool TryAddModule(ModuleBase module)
        {
            if (module is WeaponModule weaponModule && _weaponModules.Count < WeaponSlotsCount)
            {
                _weaponModules.Add(weaponModule);
                module.OnStart();
                OnStatsChanged?.Invoke();
                return true;
            }
            if (module is StatsAffectorModuleBase statsAffectorModule && _statsModules.Count < CommonModulesSlotsCount)
            {
                _statsModules.Add(statsAffectorModule);
                module.OnStart();
                OnStatsChanged?.Invoke();
                return true;
            }

            return false;
        }

        public bool TryRemoveModule(ModuleBase module)
        {
            if (module is WeaponModule weaponModule && _weaponModules.Contains(weaponModule))
            {
                _weaponModules.Remove(weaponModule);
                module.OnStop();
                OnStatsChanged?.Invoke();
                return true;
            }
            if (module is StatsAffectorModuleBase statsAffectorModule && _statsModules.Contains(statsAffectorModule) )
            {
                _statsModules.Remove(statsAffectorModule);
                module.OnStop();
                OnStatsChanged?.Invoke();
                return true;
            }
            
            return false;
        }

        public override string ToString()
        {
            var properties = GetType().GetProperties();

            var stringBuilder = new StringBuilder();
            foreach (var prop in properties)
            {
                if(prop.PropertyType != typeof(int))
                    continue;
                stringBuilder.Append('-').Append(prop.Name).Append(':').Append(' ')
                    .Append(prop.GetValue(this))
                    .Append('\n');
            }
            
            stringBuilder.Append('-').Append(nameof(CurrentShieldRegenerationPerSecond)).Append(':').Append(' ')
                .Append(CurrentShieldRegenerationPerSecond)
                .Append('\n');
            
            stringBuilder.Append('\n');
            
            stringBuilder.Append("*** WEAPONS INFO ***")
                .Append('\n');

            var totalWeapons = _weaponModules.Count;
            stringBuilder.Append('-').Append(nameof(totalWeapons)).Append(':').Append(' ')
                .Append(totalWeapons)
                .Append('\n');

            var totalWeaponsDamage = 0;
            _weaponModules.ForEach(w => totalWeaponsDamage += w.CurrentDamage);
            
            stringBuilder.Append('-').Append(nameof(totalWeaponsDamage)).Append(':').Append(' ')
                .Append(totalWeaponsDamage)
                .Append('\n');

            float totalWeaponsDelay = 0;
            _weaponModules.ForEach(w => totalWeaponsDelay += w.CurrentDelay);
            
            stringBuilder.Append('-').Append(nameof(totalWeaponsDelay)).Append(':').Append(' ')
                .Append(totalWeaponsDelay)
                .Append('\n');

            return stringBuilder.ToString();
        }
    }
}
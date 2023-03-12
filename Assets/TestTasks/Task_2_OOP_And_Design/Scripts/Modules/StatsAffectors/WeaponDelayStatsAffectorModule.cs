using System.Collections.Generic;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules.StatsAffectors
{
    public class WeaponDelayStatsAffectorModule : WeaponStatsAffectorModuleBase
    {
        private readonly float _delayModifier;

        public WeaponDelayStatsAffectorModule(float delayModifier,IEnumerable<WeaponModule> weaponModules) : base(weaponModules)
        {
            _delayModifier = delayModifier;
        }

        public override void OnStartUse()
        {
            foreach (var weaponModule in _weaponModules)
            {
                weaponModule.CurrentDelay = weaponModule.BaseDelay * _delayModifier;
            }
        }

        public override void OnStopUse()
        {
            foreach (var weaponModule in _weaponModules)
            {
                weaponModule.CurrentDelay = weaponModule.BaseDelay;
            }
        }
    }
}
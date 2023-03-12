using System.Collections.Generic;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules.StatsAffectors
{
    public abstract class WeaponStatsAffectorModuleBase : StatsAffectorModuleBase
    {
        protected readonly IEnumerable<WeaponModule> _weaponModules;

        public WeaponStatsAffectorModuleBase(IEnumerable<WeaponModule> weaponModules)
        {
            _weaponModules = weaponModules;
        }
    }
}
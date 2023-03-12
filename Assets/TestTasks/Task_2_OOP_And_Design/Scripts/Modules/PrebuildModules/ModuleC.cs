using System.Collections.Generic;
using TestTasks.Task_2_OOP_And_Design.Scripts.Modules.StatsAffectors;
using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules.PrebuildModules
{
    public class ModuleC : MacroModule
    {
        public ModuleC(VehicleStats vehicleStats, IEnumerable<WeaponModule> weaponModules) : base(new WeaponDelayStatsAffectorModule(0.8f, weaponModules))
        {
            
        }
    }
}
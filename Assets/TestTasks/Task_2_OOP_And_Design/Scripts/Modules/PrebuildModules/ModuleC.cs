using TestTasks.Task_2_OOP_And_Design.Scripts.Modules.StatsAffectors;
using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules.PrebuildModules
{
    public class ModuleC : WeaponDelayStatsAffectorModule
    {
        public ModuleC(VehicleStats vehicleStats, params WeaponModule[] weaponModules) : base( 0.8f, weaponModules)
        {
            
        }
    }
}
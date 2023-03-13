using TestTasks.Task_2_OOP_And_Design.Scripts.Modules.StatsAffectors;
using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules.PrebuildModules
{
    public class ModuleB : VehicleHpValueAffectorModule
    {
        public ModuleB(VehicleStats vehicleStats) : base(50, vehicleStats)
        {
            
        }
    }
}
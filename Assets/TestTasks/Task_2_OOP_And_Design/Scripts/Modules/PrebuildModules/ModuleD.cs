using TestTasks.Task_2_OOP_And_Design.Scripts.Modules.StatsAffectors;
using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules.PrebuildModules
{
    public class ModuleD : VehicleShieldRegenerationAffectorModule
    {
        public ModuleD(VehicleStats vehicleStats) : base(1.2f, vehicleStats)
        {
            
        }
    }
}
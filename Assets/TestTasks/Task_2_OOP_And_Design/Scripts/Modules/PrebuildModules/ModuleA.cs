using TestTasks.Task_2_OOP_And_Design.Scripts.Modules.StatsAffectors;
using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules.PrebuildModules
{
    public class ModuleA : MacroModule
    {
        public ModuleA(VehicleStats vehicleStats) : base(new VehicleShieldValueAffectorModule(50, vehicleStats))
        {
            
        }
    }
}
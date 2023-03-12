using TestTasks.Task_2_OOP_And_Design.Scripts.Modules.StatsAffectors;
using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules.PrebuildModules
{
    public class ModuleD : MacroModule
    {
        public ModuleD(VehicleStats vehicleStats) : base(new VehicleShieldRegenerationAffectorModule(1.2f, vehicleStats))
        {
            
        }
    }
}
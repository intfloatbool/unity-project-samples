using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules.StatsAffectors
{
    public abstract class VehicleStatsAffectorModuleBase : StatsAffectorModuleBase
    {
        protected readonly VehicleStats _vehicleStats;

        public VehicleStatsAffectorModuleBase(VehicleStats vehicleStats)
        {
            _vehicleStats = vehicleStats;
        }
    }
}
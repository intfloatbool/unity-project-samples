using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules.StatsAffectors
{
    public class VehicleShieldValueAffectorModule : VehicleStatsAffectorModuleBase
    {
        private readonly int _additionalValue;

        public VehicleShieldValueAffectorModule(int additionalValue, VehicleStats vehicleStats) : base(vehicleStats)
        {
            _additionalValue = additionalValue;
        }

        public override void OnStart()
        {
            _vehicleStats.MaxShield = _vehicleStats.BaseShield + _additionalValue;
            _vehicleStats.CurrentShield = _vehicleStats.MaxShield;
        }

        public override void OnStop()
        {
            _vehicleStats.MaxShield = _vehicleStats.BaseShield;
            _vehicleStats.CurrentShield = _vehicleStats.MaxShield;
        }
    }
}
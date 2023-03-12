using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules.StatsAffectors
{
    public class VehicleHpValueAffectorModule : VehicleStatsAffectorModuleBase
    {
        private readonly int _additionalValue;

        public VehicleHpValueAffectorModule(int additionalValue, VehicleStats vehicleStats) : base(vehicleStats)
        {
            _additionalValue = additionalValue;
        }

        public override void OnStartUse()
        {
            _vehicleStats.MaxHp = _vehicleStats.BaseHp + _additionalValue;
            _vehicleStats.CurrentHp = _vehicleStats.MaxHp;
        }

        public override void OnStopUse()
        {
            _vehicleStats.MaxHp = _vehicleStats.BaseHp;
            _vehicleStats.CurrentHp = _vehicleStats.MaxHp;
        }
    }
}
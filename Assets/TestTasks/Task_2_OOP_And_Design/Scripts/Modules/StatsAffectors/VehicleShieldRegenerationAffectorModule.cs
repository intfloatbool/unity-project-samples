using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;
using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules.StatsAffectors
{
    public class VehicleShieldRegenerationAffectorModule : VehicleStatsAffectorModuleBase
    {
        private readonly float _shieldRegenerationModifier;

        public VehicleShieldRegenerationAffectorModule(float shieldRegenerationModifier, VehicleStats vehicleStats) : base(vehicleStats)
        {
            _shieldRegenerationModifier = shieldRegenerationModifier;
        }

        public override void OnStart()
        {
            _vehicleStats.CurrentShieldRegenerationPerSecond =
                _vehicleStats.BaseShieldRegenerationPerSecond * _shieldRegenerationModifier;

        }

        public override void OnStop()
        {
            _vehicleStats.CurrentShieldRegenerationPerSecond =
                _vehicleStats.BaseShieldRegenerationPerSecond;
        }
        
    }
}
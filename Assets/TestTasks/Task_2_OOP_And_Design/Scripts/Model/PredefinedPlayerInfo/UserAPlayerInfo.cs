using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Model.PredefinedPlayerInfo
{
    public class UserAPlayerInfo : PlayerInfoBase
    {
        private VehicleStats _vehicleStats = new VehicleStats()
        {
            WeaponSlotsCount = 2,
            CommonModulesSlotsCount = 2,
            MaxHp = 100,
            BaseHp = 100,
            CurrentHp = 100,
            MaxShield = 80,
            BaseShield = 80,
            CurrentShield = 80,
            BaseShieldRegenerationPerSecond = 1,
            CurrentShieldRegenerationPerSecond = 1,
        };

        public override VehicleStats GetVehicleStats() => _vehicleStats;
    }
}
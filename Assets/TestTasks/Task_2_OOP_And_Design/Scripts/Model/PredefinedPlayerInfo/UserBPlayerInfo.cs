using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Model.PredefinedPlayerInfo
{
    public class UserBPlayerInfo : PlayerInfoBase
    {
        private VehicleStats _vehicleStats = new VehicleStats()
        {
            WeaponSlotsCount = 2,
            CommonModulesSlotsCount = 3,
            MaxHp = 60,
            BaseHp = 60,
            CurrentHp = 60,
            MaxShield = 120,
            BaseShield = 120,
            CurrentShield = 120,
            BaseShieldRegenerationPerSecond = 1,
            CurrentShieldRegenerationPerSecond = 1,
        };

        public override VehicleStats GetVehicleStats() => _vehicleStats;
    }
}
namespace TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle
{
    public class VehicleStats
    {
        public int BaseHp { get; set; }
        public int BaseShield { get; set; }
        public int MaxHp { get; set; }
        public int MaxShield { get;  set; }
        public int CurrentHp { get; set;}
        public int CurrentShield { get; set;}
        public float BaseHpRegenerationPerSecond { get; set; }
        public float CurrentHpRegenerationPerSecond { get; set; }
        public float BaseShieldRegenerationPerSecond { get; set; }
        public float CurrentShieldRegenerationPerSecond { get; set; }

        public VehicleStats Clone()
        {
            return MemberwiseClone() as VehicleStats;
            
        }
    }
}
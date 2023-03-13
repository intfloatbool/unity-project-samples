using System.Collections.Generic;
using TestTasks.Task_2_OOP_And_Design.Scripts.Modules.PrebuildModules;
using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules.ModulesProviders
{
    public class PredefinedVehicleModulesProvider : IPossibleModulesProvider
    {
        private readonly VehicleStats _vehicleStats;
        public PredefinedVehicleModulesProvider(VehicleStats vehicleStats)
        {
            _vehicleStats = vehicleStats;
        }
        
        public IEnumerable<ModuleBase> ProvidePossibleModules()
        {
            var weaponA = new WeaponA();
            var weaponB = new WeaponB();
            var weaponC = new WeaponC();
            yield return weaponA;
            yield return weaponB;
            yield return weaponC;
            yield return new ModuleA(_vehicleStats);
            yield return new ModuleB(_vehicleStats);
            yield return new ModuleC(_vehicleStats, weaponA, weaponB, weaponC);
            yield return new ModuleD(_vehicleStats);
        }
    }
}
using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle
{
    public class VehicleBuilder
    {
        private readonly VehicleShip _shipPrefab;

        public VehicleBuilder(VehicleShip shipPrefab)
        {
            _shipPrefab = shipPrefab;
        }

        public VehicleShip Build()
        {
            //TODO:
            var instance = Object.Instantiate(_shipPrefab);
            //instance.Init();
            return null;
        }
    }
}
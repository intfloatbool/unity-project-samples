using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle
{
    [RequireComponent(typeof(VehicleShip))]
    public class VehicleDebugCheats : MonoBehaviour
    {
        [SerializeField] private bool _isEnabled;
        
        private VehicleShip _vehicleShip;
        private void Awake()
        {
            _vehicleShip = GetComponent<VehicleShip>();
        }

        private void Update()
        {
            if(!_isEnabled)
                return;

            if (Input.GetKeyDown(KeyCode.N))
            {
                _vehicleShip.ReceiveDamage(50);
            }
            
            if (Input.GetKeyDown(KeyCode.M))
            {
                _vehicleShip.CurrentVehicleStats.CurrentShieldRegenerationPerSecond = 10f;
            }
        }
    }
}
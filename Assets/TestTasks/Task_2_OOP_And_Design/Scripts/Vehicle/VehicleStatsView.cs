using UnityEngine;
using UnityEngine.UI;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle
{
    public class VehicleStatsView : MonoBehaviour
    {
        [Space]
        [SerializeField] private Image _hpBar;
        [SerializeField] private Image _shieldBar;
        [SerializeField] private Gradient _hpGradient;
        [SerializeField] private Gradient _shieldGradient;
        private VehicleStats _vehicleStats;

        public void Init(VehicleStats vehicleStats)
        {
            _vehicleStats = vehicleStats;
            _vehicleStats.OnStatsChanged += HandleOnVehicleStatsChanged;
            UpdateBars();
        }

        private void OnDestroy()
        {
            if (_vehicleStats != null)
                _vehicleStats.OnStatsChanged -= HandleOnVehicleStatsChanged;
        }


        private void HandleOnVehicleStatsChanged()
        {
            UpdateBars();
        }

        private void UpdateBars()
        {
            var stats = _vehicleStats;
            var hpNormalized = stats.CurrentHp / (float) stats.MaxHp;
            var shieldNormalized = stats.CurrentShield / (float) stats.MaxShield;

            var hpColor = _hpGradient.Evaluate(hpNormalized);
            var shieldColor = _shieldGradient.Evaluate(shieldNormalized);

            _hpBar.color = hpColor;
            _shieldBar.color = shieldColor;
            
            _hpBar.fillAmount = hpNormalized;
            _shieldBar.fillAmount = shieldNormalized;
        }

        
    }
}
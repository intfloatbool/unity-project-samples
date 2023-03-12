using System;
using UnityEngine;

namespace TestTasks.Task_1_Algorithms_And_DataStructures.Scripts
{
    public class StationsSelector : MonoBehaviour
    {
        [SerializeField] private SubwaySystemView _subwaySystem;
        private bool _isStationFromState = true;

        public event Action<SubwayStationView> OnStationFromSelected; 
        public event Action<SubwayStationView> OnStationToSelected;

        private SubwayStationView _lastSelected;

        private void Awake()
        {
            _subwaySystem.OnStationClicked += HandleOnStationClicked;
        }

        private void OnDestroy()
        {
            _subwaySystem.OnStationClicked -= HandleOnStationClicked;
        }

        private void HandleOnStationClicked(SubwayStationView stationView)
        {
            if(stationView == _lastSelected)
                return;
            
            if (_isStationFromState)
            {
                OnStationFromSelected?.Invoke(stationView);
            }
            else
            {
                OnStationToSelected?.Invoke(stationView);
            }
            _isStationFromState = !_isStationFromState;
            _lastSelected = stationView;
        }
    }
}
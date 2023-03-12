using System;
using TMPro;
using UnityEngine;

namespace TestTasks.Task_1_Algorithms_And_DataStructures.Scripts.UI
{
    public class GUIStationSelectionInfo : MonoBehaviour
    {
        [SerializeField] private StationsSelector _selector;
        
        [Space]
        [SerializeField] private TextMeshProUGUI _stationFromText;
        [SerializeField] private TextMeshProUGUI _stationToText;

        private void Awake()
        {
            _selector.OnStationFromSelected += HandleOnStationFromSelected;
            _selector.OnStationToSelected += HandleOnStationToSelected;
        }

        private void OnDestroy()
        {
            _selector.OnStationFromSelected -= HandleOnStationFromSelected;
            _selector.OnStationToSelected -= HandleOnStationToSelected;
        }

        private void HandleOnStationFromSelected(SubwayStationView stationView)
        {
            _stationFromText.text = $"Station From: {stationView}";
        }
        
        private void HandleOnStationToSelected(SubwayStationView stationView)
        {
            _stationToText.text = $"Station To: {stationView}";
        }
        
    }
}
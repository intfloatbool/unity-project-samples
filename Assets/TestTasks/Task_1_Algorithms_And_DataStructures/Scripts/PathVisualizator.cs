using System;
using System.Collections.Generic;
using System.Linq;
using TestTasks.Task_1_Algorithms_And_DataStructures.Scripts.BusinessLogic;
using TMPro;
using UnityEngine;

namespace TestTasks.Task_1_Algorithms_And_DataStructures.Scripts
{
    public class PathVisualizator : MonoBehaviour
    {
        [SerializeField] private StationsSelector _selector;
        [SerializeField] private SubwaySystemView _subwaySystem;
        [SerializeField] private TextMeshProUGUI _transitionsCountText;
        
        private SubwayStationView _selectedFrom;
        private SubwayStationView _selectedTo;

        private Dictionary<ValueTuple<string, EStationColorType>, SubwayStationView> _stationsViewMap;

        private void Awake()
        {
            _selector.OnStationFromSelected += HandleOnStationFromSelected;
            _selector.OnStationToSelected += HandleOnStationToSelected;
        }

        private void Start()
        {
            InitStationViewsCache();
        }

        private void InitStationViewsCache()
        {
            _stationsViewMap =
                new Dictionary<(string, EStationColorType), SubwayStationView>(_subwaySystem.StationViews.Count);
            foreach (var stationVew in _subwaySystem.StationViews)
            {
                var key = new ValueTuple<string, EStationColorType>(stationVew.Label, stationVew.ColorType);
                
                _stationsViewMap.Add(key, stationVew);
            }
        }

        private void OnDestroy()
        {
            _selector.OnStationFromSelected -= HandleOnStationFromSelected;
            _selector.OnStationToSelected -= HandleOnStationToSelected;
        }
        
        private void HandleOnStationFromSelected(SubwayStationView stationView)
        {
            _selectedFrom = stationView;
        }
        
        private void HandleOnStationToSelected(SubwayStationView stationView)
        {
            _selectedTo = stationView;
        }

        public void Show()
        {
            if(!_selectedFrom || !_selectedTo)
                return;

            var nodeFrom =
                _subwaySystem.Graph.Nodes.FirstOrDefault(n => IsCanBeWrappedFromViewToModel(_selectedFrom, n));
            
            var nodeTo =
                _subwaySystem.Graph.Nodes.FirstOrDefault(n => IsCanBeWrappedFromViewToModel(_selectedTo, n));

            var pathEdges = _subwaySystem.Graph.GenerateShortestPathByDijkstraAlgorithm(nodeFrom, nodeTo);
            var totalNodesList = new HashSet<GenericNode<SubwayStation>>(pathEdges.Count * 2);

            foreach (var edge in pathEdges)
            {
                if(edge.From != null)
                    totalNodesList.Add(edge.From);
                if(edge.To != null)
                    totalNodesList.Add(edge.To);
            }

            var transitionCount = 0;
            EStationColorType lastStationColor = totalNodesList.FirstOrDefault()?.Data.ColorType ?? EStationColorType.NONE;
            foreach (var node in totalNodesList)
            {
                if (lastStationColor != node.Data.ColorType)
                {
                    transitionCount++;
                    lastStationColor = node.Data.ColorType;
                }
            }

            if (_transitionsCountText)
                _transitionsCountText.text = $"Transitions: {transitionCount}";
            
            var viewsCollection = NodesToView(totalNodesList);
            foreach (var view in viewsCollection)
            {
                view.Highlight();
            }

        }

        private IEnumerable<SubwayStationView> NodesToView(IEnumerable<GenericNode<SubwayStation>> nodes)
        {
            foreach (var node in nodes)
            {
                var data = node.Data;
                var key = new ValueTuple<string, EStationColorType>(data.Label, data.ColorType);
                
                yield return _stationsViewMap[key];
            }
        }

        private bool IsCanBeWrappedFromViewToModel(SubwayStationView view, GenericNode<SubwayStation> node)
        {
            var nodeData = node.Data;
            return view.Label.Equals(nodeData.Label) && view.ColorType == nodeData.ColorType;
        }
    }
}
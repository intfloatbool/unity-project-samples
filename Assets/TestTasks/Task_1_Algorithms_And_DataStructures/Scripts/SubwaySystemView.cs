using System.Collections.Generic;
using System.Linq;
using TestTasks.Task_1_Algorithms_And_DataStructures.Scripts.BusinessLogic;
using UnityEngine;

namespace TestTasks.Task_1_Algorithms_And_DataStructures.Scripts
{
    public class SubwaySystemView : MonoBehaviour
    {
        private GenericGraph<SubwayStation> _graph;
        private Dictionary<EStationColorType, List<GenericNode<SubwayStation>>> _stationsMap;
        private void Awake()
        {
            (_graph, _stationsMap) = new SubwayGraphCreator().CreateGraph();
        }

        [ContextMenu("SubwayDebugTest")]
        private void SubwayDebugTest()
        {
            var redNodeA = _stationsMap[EStationColorType.RED].FirstOrDefault(s => s.Data.Label.Equals("A"));
            var blueNodeO = _stationsMap[EStationColorType.BLUE].FirstOrDefault(s => s.Data.Label.Equals("O"));
            var fromRedA2BlueO = _graph.GenerateShortestPathByDijkstraAlgorithm(redNodeA, blueNodeO);
            int counter = 0;
            string pathStr = string.Empty;
            fromRedA2BlueO.ForEach(e =>
            {
                var from = e.From.Data;
                var to = e.To.Data;
                pathStr += $"\n#{counter}: {from.ColorType}_{from.Label} -> {to.ColorType}_{to.Label}";
                
                counter++;
            });
            
            Debug.Log($"From redNodeA to blueNodeO -> Result path below:{pathStr}");
            
            
            
            var blackNodeH = _stationsMap[EStationColorType.BLACK].FirstOrDefault(s => s.Data.Label.Equals("H"));
            var blueNodeN = _stationsMap[EStationColorType.BLUE].FirstOrDefault(s => s.Data.Label.Equals("N"));
            var fromBlackH2BlueN = _graph.GenerateShortestPathByDijkstraAlgorithm(blackNodeH, blueNodeN);
            counter = 0;
            pathStr = string.Empty;
            fromBlackH2BlueN.ForEach(e =>
            {
                var from = e.From.Data;
                var to = e.To.Data;
                pathStr += $"\n#{counter}: {from.ColorType}_{from.Label} -> {to.ColorType}_{to.Label}";
                
                counter++;
            });
            
            Debug.Log($"From blackNodeH to blueNodeN -> Result path below:{pathStr}");
        }
    }
}
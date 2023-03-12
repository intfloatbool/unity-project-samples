using System.Collections.Generic;
using System.Linq;
using TestTasks.Task_1_Algorithms_And_DataStructures.Scripts.BusinessLogic;

namespace TestTasks.Task_1_Algorithms_And_DataStructures.Scripts
{
    public class SubwayGraphCreator
    {
        

        public (GenericGraph<SubwayStation>, Dictionary<EStationColorType, List<GenericNode<SubwayStation>>>) CreateGraph()
        {
            var graph = new GenericGraph<SubwayStation>(isDirected:false, isWeighted:true);
            
            // *** NODES ***
            
            // RED
            var nodeRedA = graph.AddNode(SubwayStation.Create("A", EStationColorType.RED));
            var nodeRedB = graph.AddNode(SubwayStation.Create("B", EStationColorType.RED));
            var nodeRedC = graph.AddNode(SubwayStation.Create("C", EStationColorType.RED));
            var nodeRedD = graph.AddNode(SubwayStation.Create("D", EStationColorType.RED));
            var nodeRedE = graph.AddNode(SubwayStation.Create("E", EStationColorType.RED));
            var nodeRedF = graph.AddNode(SubwayStation.Create("F", EStationColorType.RED));
            
            // GREEN
            var nodeGreenC = graph.AddNode(SubwayStation.Create("C", EStationColorType.GREEN));
            var nodeGreenK = graph.AddNode(SubwayStation.Create("K", EStationColorType.GREEN));
            var nodeGreenL = graph.AddNode(SubwayStation.Create("L", EStationColorType.GREEN));
            var nodeGreenM = graph.AddNode(SubwayStation.Create("M", EStationColorType.GREEN));
            var nodeGreenE = graph.AddNode(SubwayStation.Create("E", EStationColorType.GREEN));
            var nodeGreenJ = graph.AddNode(SubwayStation.Create("J", EStationColorType.GREEN));
            
            // BLUE
            var nodeBlueN = graph.AddNode(SubwayStation.Create("N", EStationColorType.BLUE));
            var nodeBlueL = graph.AddNode(SubwayStation.Create("L", EStationColorType.BLUE));
            var nodeBlueD = graph.AddNode(SubwayStation.Create("D", EStationColorType.BLUE));
            var nodeBlueJ = graph.AddNode(SubwayStation.Create("J", EStationColorType.BLUE));
            var nodeBlueO = graph.AddNode(SubwayStation.Create("O", EStationColorType.BLUE));
            
            // BLACK
            var nodeBlackB = graph.AddNode(SubwayStation.Create("B", EStationColorType.BLACK));
            var nodeBlackH = graph.AddNode(SubwayStation.Create("H", EStationColorType.BLACK));
            var nodeBlackJ = graph.AddNode(SubwayStation.Create("J", EStationColorType.BLACK));
            var nodeBlackF = graph.AddNode(SubwayStation.Create("F", EStationColorType.BLACK));
            var nodeBlackG = graph.AddNode(SubwayStation.Create("G", EStationColorType.BLACK));

            var stationNodesList = graph.Nodes.ToList();
            var stationsMap = new Dictionary<EStationColorType, List<GenericNode<SubwayStation>>>(stationNodesList.Count);

            stationsMap[EStationColorType.RED] = stationNodesList.Where(s => s.Data.ColorType == EStationColorType.RED).ToList();
            stationsMap[EStationColorType.GREEN] = stationNodesList.Where(s => s.Data.ColorType == EStationColorType.GREEN).ToList();
            stationsMap[EStationColorType.BLUE] = stationNodesList.Where(s => s.Data.ColorType == EStationColorType.BLUE).ToList();
            stationsMap[EStationColorType.BLACK] = stationNodesList.Where(s => s.Data.ColorType == EStationColorType.BLACK).ToList();


            // *** EDGES ***
            const int DEFAULT_WEIGHT = 1;
        
            // RED
            graph.AddEdge(nodeRedA, nodeRedB, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeRedB, nodeBlackB, DEFAULT_WEIGHT);
            graph.AddEdge(nodeRedB, nodeRedC, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeRedC, nodeGreenC, DEFAULT_WEIGHT);
            graph.AddEdge(nodeRedC, nodeRedD, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeRedD, nodeBlueD, DEFAULT_WEIGHT);
            graph.AddEdge(nodeRedD, nodeRedE, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeRedE, nodeGreenE, DEFAULT_WEIGHT);
            graph.AddEdge(nodeRedE, nodeRedF, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeRedF, nodeBlackF, DEFAULT_WEIGHT);

            // GREEN
            graph.AddEdge(nodeGreenC, nodeRedC, DEFAULT_WEIGHT);
            graph.AddEdge(nodeGreenC, nodeGreenK, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeGreenK, nodeGreenL, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeGreenL, nodeBlueL, DEFAULT_WEIGHT);
            graph.AddEdge(nodeGreenL, nodeGreenM, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeGreenM, nodeGreenE, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeGreenE, nodeRedE, DEFAULT_WEIGHT);
            graph.AddEdge(nodeGreenE, nodeGreenJ, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeGreenJ, nodeGreenC, DEFAULT_WEIGHT);
            graph.AddEdge(nodeGreenJ, nodeBlackJ, DEFAULT_WEIGHT);
            graph.AddEdge(nodeGreenJ, nodeBlueJ, DEFAULT_WEIGHT);

            // BLUE
            graph.AddEdge(nodeBlueN, nodeBlueL, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeBlueL, nodeGreenL, DEFAULT_WEIGHT);
            graph.AddEdge(nodeBlueL, nodeBlueD, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeBlueD, nodeRedD, DEFAULT_WEIGHT);
            graph.AddEdge(nodeBlueD, nodeBlueJ, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeBlueJ, nodeBlackJ, DEFAULT_WEIGHT);
            graph.AddEdge(nodeBlueJ, nodeGreenJ, DEFAULT_WEIGHT);
            graph.AddEdge(nodeBlueJ, nodeBlueO, DEFAULT_WEIGHT);
            
            // BLACK
            graph.AddEdge(nodeBlackB, nodeRedB, DEFAULT_WEIGHT);
            graph.AddEdge(nodeBlackB, nodeBlackH, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeBlackH, nodeBlackJ, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeBlackJ, nodeBlueJ, DEFAULT_WEIGHT);
            graph.AddEdge(nodeBlackJ, nodeGreenJ, DEFAULT_WEIGHT);
            graph.AddEdge(nodeBlackJ, nodeBlackF, DEFAULT_WEIGHT);
            
            graph.AddEdge(nodeBlackF, nodeRedF, DEFAULT_WEIGHT);
            graph.AddEdge(nodeBlackF, nodeBlackG, DEFAULT_WEIGHT);

            return (graph, stationsMap);
        }
    }
}
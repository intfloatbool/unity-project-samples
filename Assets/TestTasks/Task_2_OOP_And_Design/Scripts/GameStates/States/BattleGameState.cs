using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;
using TMPro;
using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.GameStates.States
{
    public class BattleGameState : GameStateBase
    {
        public struct VehicleInitializationDTO
        {
            public readonly VehicleStats VehicleStats;
            public readonly VehicleShip VehicleShip;

            public VehicleInitializationDTO(VehicleStats vehicleStats, VehicleShip vehicleShip)
            {
                VehicleStats = vehicleStats;
                VehicleShip = vehicleShip;
            }
        }
        
        public BattleGameState(GameFSM gameFsm, VehicleInitializationDTO vehicleDataA, VehicleInitializationDTO vehicleDataB, TextMeshProUGUI winnerText, GameObject[] relativeObjectsForEndGameState, params GameObject[] relativeGameObjects) : base(gameFsm, relativeGameObjects)
        {
            var vehicleA = vehicleDataA.VehicleShip;
            var vehicleB = vehicleDataB.VehicleShip;

            var vehicleStatsA = vehicleDataA.VehicleStats;
            var vehicleStatsB = vehicleDataB.VehicleStats;
            
            vehicleA.Init(vehicleStatsA);
            vehicleB.Init(vehicleStatsB);
            
            vehicleA.SetTarget(vehicleB);
            vehicleB.SetTarget(vehicleA);

            vehicleA.OnDestroyed += () =>
            {
                gameFsm.SetState(new EndGameState(_gameFsm, "Player B", winnerText, relativeObjectsForEndGameState));
            };

            vehicleB.OnDestroyed += () =>
            {
                gameFsm.SetState(new EndGameState(_gameFsm, "Player A", winnerText, relativeObjectsForEndGameState));
            };
        }

    }
}
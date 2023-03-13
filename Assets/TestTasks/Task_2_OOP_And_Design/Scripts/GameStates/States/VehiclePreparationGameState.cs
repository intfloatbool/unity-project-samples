using TestTasks.Task_2_OOP_And_Design.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.GameStates.States
{
    public class VehiclePreparationGameState : GameStateBase
    {
        private readonly PlayerInitializationFromUIDTO _player1DTO;
        private readonly PlayerInitializationFromUIDTO _player2DTO;

        public VehiclePreparationGameState(GameFSM gameFsm, PlayerInitializationFromUIDTO player1DTO, PlayerInitializationFromUIDTO player2DTO, params GameObject[] relativeGameObjects) : base(gameFsm, relativeGameObjects)
        {
            _player1DTO = player1DTO;
            _player2DTO = player2DTO;
            
            
        }
        
        public override void OnStart()
        {
            base.OnStart();

            InitUiByPlayerDTO(_player1DTO);
            InitUiByPlayerDTO(_player2DTO);
        }
        
        
        private void InitUiByPlayerDTO(PlayerInitializationFromUIDTO playerDTO)
        {
            playerDTO.UIElementsCreator.Init(playerDTO.PlayerInfo.GetVehicleStats(), playerDTO.PossibleModulesProvider);
            playerDTO.UIElementsCreator.RecreateModuleRepresentations();
        }

    }
}
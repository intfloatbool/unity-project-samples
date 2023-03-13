using TestTasks.Task_2_OOP_And_Design.Scripts.GameStates;
using TestTasks.Task_2_OOP_And_Design.Scripts.GameStates.States;
using TestTasks.Task_2_OOP_And_Design.Scripts.Model;
using TestTasks.Task_2_OOP_And_Design.Scripts.Model.PredefinedPlayerInfo;
using TestTasks.Task_2_OOP_And_Design.Scripts.Modules.ModulesProviders;
using TestTasks.Task_2_OOP_And_Design.Scripts.UI;
using TestTasks.Task_2_OOP_And_Design.Scripts.Vehicle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestTasks.Task_2_OOP_And_Design.Scripts
{
    public class SceneInit : MonoBehaviour
    {
        [SerializeField] private GameFSM _gameFsm;

        [Space] 
        [Header("VehiclePreparationGameState")] 
        [SerializeField] private Button _goBattleButton;
        [SerializeField] private ModulesUIElementsCreator _uiCreatorForPlayerA;
        [SerializeField] private ModulesUIElementsCreator _uiCreatorForPlayerB;
        [SerializeField] private GameObject[] _relativeObjectsForVehiclePreparationGameState;

        [Space] 
        [Header("BattleGameState")]
        [SerializeField] private VehicleShip _vehicleA;
        [SerializeField] private VehicleShip _vehicleB;
        [SerializeField] private GameObject[] _relativeObjectsForBattleGameState;
        
        [Space] 
        [Header("EndGameState")]
        [SerializeField] private TextMeshProUGUI _winnerText;
        [SerializeField] private GameObject[] _relativeObjectsForEndGameState;


        private void Start()
        {
            var playerInfoA = new UserAPlayerInfo();
            var playerInfoB = new UserBPlayerInfo();
            
            _gameFsm.SetState(new VehiclePreparationGameState(
                _gameFsm,
                
                new PlayerInitializationFromUIDTO(_uiCreatorForPlayerA, playerInfoA, new PredefinedVehicleModulesProvider(playerInfoA.GetVehicleStats())),
                
                new PlayerInitializationFromUIDTO(_uiCreatorForPlayerB, playerInfoB, new PredefinedVehicleModulesProvider(playerInfoB.GetVehicleStats())),

                _relativeObjectsForVehiclePreparationGameState
                ));
            
            
            _goBattleButton.onClick.AddListener(() =>
            {
                _gameFsm.SetState(new BattleGameState(_gameFsm, 
                    
        new BattleGameState.VehicleInitializationDTO(playerInfoA.GetVehicleStats(), _vehicleA), 
                    
        new BattleGameState.VehicleInitializationDTO(playerInfoB.GetVehicleStats(), _vehicleB),
                    
                _winnerText,
        
                _relativeObjectsForEndGameState,
        _relativeObjectsForBattleGameState));
            });
        }
    }
}
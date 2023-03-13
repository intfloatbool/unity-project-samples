using TMPro;
using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.GameStates.States
{
    public class EndGameState : GameStateBase
    {
        public EndGameState(GameFSM gameFsm, string winnerName, TextMeshProUGUI winnerText, params GameObject[] relativeGameObjects) : base(gameFsm, relativeGameObjects)
        {
            winnerText.text = winnerName;
        }
    }
}
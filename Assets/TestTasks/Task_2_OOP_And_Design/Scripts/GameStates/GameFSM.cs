using TestTasks.Task_2_OOP_And_Design.Scripts.GameStates.States;
using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.GameStates
{
    public class GameFSM : MonoBehaviour
    {
        private GameStateBase _currentState = new NullGameState();

        public void SetState(GameStateBase gameState)
        {
            _currentState?.OnStop();

            _currentState = gameState;
            _currentState.OnStart();
        }

        private void Update()
        {
            _currentState?.OnFrame();
        }
    }
}
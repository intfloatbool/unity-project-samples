namespace TestTasks.Task_2_OOP_And_Design.Scripts.GameStates.States
{
    public class NullGameState : GameStateBase
    {
        public override void OnStart()
        {
            
        }

        public override void OnStop()
        {
           
        }

        public NullGameState() : base(null)
        {
        }
    }
}
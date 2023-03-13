namespace TestTasks.Task_2_OOP_And_Design.Scripts.Model
{
    public interface ITickableCommand : ICommand
    {
        void OnFrame();
    }
}
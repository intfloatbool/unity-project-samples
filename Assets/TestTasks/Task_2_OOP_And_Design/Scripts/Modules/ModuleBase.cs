namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules
{
    public abstract class ModuleBase
    {
        public abstract void OnStartUse();
        public abstract void OnStopUse();
        public virtual void OnFrame() {}
    }
}
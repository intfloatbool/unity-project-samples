using TestTasks.Task_2_OOP_And_Design.Scripts.Model;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules
{
    public abstract class ModuleBase : ITickableCommand
    {
        public abstract void OnStart();

        public abstract void OnStop();

        public virtual void OnFrame() {}

        public override string ToString()
        {
            return GetType().Name;
        }
        
        public virtual void Init(params object[] args) {}
    }
}
using System;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Targeting
{
    public interface IDestroyable
    {
        event Action OnDestroyed;
        bool IsDestroyed { get; }
    }
}
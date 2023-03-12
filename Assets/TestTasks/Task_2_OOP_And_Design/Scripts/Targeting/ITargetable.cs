using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Targeting
{
    public interface ITargetable
    {
        Vector3? CurrentPosition { get; }
    }
}
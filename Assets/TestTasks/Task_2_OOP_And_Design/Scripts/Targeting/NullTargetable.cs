using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Targeting
{
    public class NullTargetable : ITargetable
    {
        public Vector3? CurrentPosition => null;
    }
}
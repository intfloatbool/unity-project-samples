using System.Collections.Generic;

namespace TestTasks.Task_1_Algorithms_And_DataStructures.Scripts.BusinessLogic
{
    public class GenericNode<T>
    {
        public int Index { get; set; }
        public T Data { get; set; }

        public List<GenericNode<T>> Neighbors { get; set; }
            = new();
        public List<int> Weights { get; set; } = new List<int>();
        public override string ToString()
        {
            return $"Node with index {Index}: {Data}, neighbors: {Neighbors.Count}";
        }
    }
}
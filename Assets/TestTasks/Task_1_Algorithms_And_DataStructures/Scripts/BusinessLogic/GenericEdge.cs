namespace TestTasks.Task_1_Algorithms_And_DataStructures.Scripts.BusinessLogic
{
    public class GenericEdge<T>
    {
        public GenericNode<T> From { get; set; }
        public GenericNode<T> To { get; set; }
        public int Weight { get; set; }
        public override string ToString()
        {
            return $"Edge: {From.Data} -> {To.Data},weight: {Weight}";
        }
    }
}
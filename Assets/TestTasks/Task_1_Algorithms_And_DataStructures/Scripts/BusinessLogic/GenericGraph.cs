using System.Collections.Generic;
using Priority_Queue;

namespace TestTasks.Task_1_Algorithms_And_DataStructures.Scripts.BusinessLogic
{
    public class GenericGraph<T>
    {
        private bool _isDirected = false;
        private bool _isWeighted = false;
        public List<GenericNode<T>> Nodes { get; set; }
            = new List<GenericNode<T>>();
        
        public GenericGraph(bool isDirected, bool isWeighted)
        {
            _isDirected = isDirected;
            _isWeighted = isWeighted;
        }
        
        public GenericEdge<T> this[int from, int to]
        {
            get
            {
                GenericNode<T> nodeFrom = Nodes[from];
                GenericNode<T> nodeTo = Nodes[to];
                int i = nodeFrom.Neighbors.IndexOf(nodeTo);
                if (i >= 0)
                {
                    GenericEdge<T> edge = new GenericEdge<T>()
                    {
                        From = nodeFrom,
                        To = nodeTo,
                        Weight = i < nodeFrom.Weights.Count
                            ? nodeFrom.Weights[i] : 0
                    };
                    return edge;
                }
                return null;
            }
        }
        
        public GenericNode<T> AddNode(T value)
        {
            GenericNode<T> node = new GenericNode<T>() { Data = value };
            Nodes.Add(node);
            UpdateIndices();
            return node;
        }
        
        public void RemoveNode(GenericNode<T> nodeToRemove)
        {
            Nodes.Remove(nodeToRemove);
            UpdateIndices();
            foreach (GenericNode<T> node in Nodes)
            {
                RemoveEdge(node, nodeToRemove);
            }
        }
        
        private void UpdateIndices()
        {
            int i = 0;
            Nodes.ForEach(n => n.Index = i++);
        }
        
        public void AddEdge(GenericNode<T> from, GenericNode<T> to, int weight = 0)
        {
            from.Neighbors.Add(to);
            if (_isWeighted)
            {
                from.Weights.Add(weight);
            }
            if (!_isDirected)
            {
                to.Neighbors.Add(from);
                if (_isWeighted)
                {
                    to.Weights.Add(weight);
                }
            }
        }
        
        public void RemoveEdge(GenericNode<T> from, GenericNode<T> to)
        {
            int index = from.Neighbors.FindIndex(n => n == to);
            if (index >= 0)
            {
                from.Neighbors.RemoveAt(index);
                if (_isWeighted)
                {
                    from.Weights.RemoveAt(index);
                }
            }
        }
        
        public List<GenericEdge<T>> GetEdges()
        {
            List<GenericEdge<T>> edges = new List<GenericEdge<T>>();
            foreach (GenericNode<T> from in Nodes)
            {
                for (int i = 0; i < from.Neighbors.Count; i++)
                {
                    GenericEdge<T> edge = new GenericEdge<T>()
                    {
                        From = from,
                        To = from.Neighbors[i],
                        Weight = i < from.Weights.Count
                            ? from.Weights[i] : 0
                    };
                    edges.Add(edge);
                }
            }
            return edges;
        }
        
        private void Fill<Q>(Q[] array, Q value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }
        
        public List<GenericEdge<T>> GenerateShortestPathByDijkstraAlgorithm(
            GenericNode<T> source, GenericNode<T> target)
        {
            int[] previous = new int[Nodes.Count];
            Fill(previous, -1);
            int[] distances = new int[Nodes.Count];
            Fill(distances, int.MaxValue);
            distances[source.Index] = 0;
        
            SimplePriorityQueue<GenericNode<T>> nodes =
                new SimplePriorityQueue<GenericNode<T>>();
            for (int i = 0; i < Nodes.Count; i++)
            {
                nodes.Enqueue(Nodes[i], distances[i]);
            }
            while (nodes.Count != 0)
            {
                GenericNode<T> node = nodes.Dequeue();
                for (int i = 0; i < node.Neighbors.Count; i++)
                {
                    GenericNode<T> neighbor = node.Neighbors[i];
                    int weight = i < node.Weights.Count
                        ? node.Weights[i] : 0;
                    int weightTotal = distances[node.Index] + weight;
                    if (distances[neighbor.Index] > weightTotal)
                    {
                        distances[neighbor.Index] = weightTotal;
                        previous[neighbor.Index] = node.Index;
                        nodes.UpdatePriority(neighbor,
                            distances[neighbor.Index]);
                    }
                }
            }
            List<int> indices = new List<int>();
            int index = target.Index;
            while (index >= 0)
            {
                indices.Add(index);
                index = previous[index];
            }
            indices.Reverse();
            List<GenericEdge<T>> result = new List<GenericEdge<T>>();
            for (int i = 0; i < indices.Count - 1; i++)
            {
                GenericEdge<T> edge = this[indices[i], indices[i + 1]];
                result.Add(edge);
            }
            return result;
        }
        
    }
}
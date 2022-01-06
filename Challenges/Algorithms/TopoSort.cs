using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.Algorithms
{
    public class TopologicalSort
    {
        /// <summary>
        ///L ← Empty list that will contain the sorted elements
        ///S ← Set of all nodes with no incoming edge
        ///while S is non-empty do
        ///    remove a node n from S
        ///    add n to tail of L
        ///    for each node m with an edge e from n to m do
        ///        remove edge e from the graph
        ///        if m has no other incoming edges then
        ///            insert m into S
        ///if graph has edges then
        ///    return error (graph has at least one cycle)
        ///else 
        ///    return L (a topologically sorted order)
        /// </summary>
        public static IEnumerable<int> SortGraph(bool[][] graph)
        {
            int[] edges = new int[graph.Length];

            var topoSortedNodes = new List<int>();
            var nodesWithNoEdges = new PriorityQueue<int>();
            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph.Length; j++)
                {
                    if (graph[j][i])
                        edges[i]++;
                }
                if (edges[i] == 0)
                    nodesWithNoEdges.Enqueue(i);
            }

            while (!nodesWithNoEdges.IsEmpty)
            {
                int curr = nodesWithNoEdges.DequeueMin();
                topoSortedNodes.Add(curr);

                for (int i = 0; i < graph.Length; i++)
                {
                    if (graph[curr][i])
                    {
                        edges[i]--;

                        if (edges[i] == 0)
                            nodesWithNoEdges.Enqueue(i);
                    }
                }
            }

            if (topoSortedNodes.Count != graph.Length)
                // graph has cycles
                return null;
            else
                return topoSortedNodes;
        }

        public static IEnumerable<int> SortGraph(List<HashSet<int>> graph)
        {
            int[] edges = new int[graph.Count];

            var topoSortedNodes = new List<int>();
            var nodesWithNoEdges = new PriorityQueue<int>();
            for (int i = 0; i < graph.Count; i++)
            {
                for (int j = 0; j < graph.Count; j++)
                {
                    if (graph[j].Contains(i))
                        edges[i]++;
                }
                if (edges[i] == 0)
                    nodesWithNoEdges.Enqueue(i);
            }

            while (!nodesWithNoEdges.IsEmpty)
            {
                int curr = nodesWithNoEdges.DequeueMin();
                topoSortedNodes.Add(curr);

                foreach (int i in graph[curr])
                {
                    edges[i]--;

                    if (edges[i] == 0)
                        nodesWithNoEdges.Enqueue(i);
                }
            }

            if (topoSortedNodes.Count != graph.Count)
                // graph has cycles
                return null;
            else
                return topoSortedNodes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.CourseSchedule2
{
    public class Solution
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            bool[][] graph = new bool[numCourses][];
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new bool[numCourses];
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                int from = prerequisites[i][0];
                int to = prerequisites[i][1];
                graph[from][to] = true;
            }

            var solution = SortGraph(graph) ?? Enumerable.Empty<int>();
            return solution.Reverse().ToArray();
        }

        public static IEnumerable<int> SortGraph(bool[][] graph)
        {
            int[] edges = new int[graph.Length];

            var topoSortedNodes = new List<int>();
            var nodesWithNoEdges = new LinkedList<int>();
            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph.Length; j++)
                {
                    if (graph[j][i])
                        edges[i]++;
                }
                if (edges[i] == 0)
                    nodesWithNoEdges.AddLast(i);
            }

            while (nodesWithNoEdges.Any())
            {
                int curr = nodesWithNoEdges.First.Value;
                nodesWithNoEdges.RemoveFirst();
                topoSortedNodes.Add(curr);

                for (int i = 0; i < graph.Length; i++)
                {
                    if (graph[curr][i])
                    {
                        edges[i]--;

                        if (edges[i] == 0)
                            nodesWithNoEdges.AddLast(i);
                    }
                }
            }

            if (topoSortedNodes.Count != graph.Length)
                // graph has cycles
                return null;
            else
                return topoSortedNodes;
        }
    }
}

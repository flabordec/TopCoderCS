using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopCoderCS.Algorithms;

namespace TopCoderCS.LeetCode.NetworkDelayTime
{
    public class SolutionFloydWarshall
    {
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            int[,] distances = MinDistancesForAllVertices(n, times);
            int max = -1;
            k = k - 1;
            for (int i = 0; i < n; i++)
            {
                if (distances[k, i] == -1)
                    return -1;

                max = Math.Max(distances[k, i], max);
            }
            return max;
        }

        public static int[,] MinDistancesForAllVertices(int n, int[][] edges)
        {
            int[,] distances = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    distances[i, j] = -1;

            for (int i = 0; i < edges.Length; i++)
            {
                int from = edges[i][0] - 1;
                int to = edges[i][1] - 1;
                int dist = edges[i][2];

                distances[from, to] = dist;
            }

            for (int i = 0; i < n; i++)
            {
                distances[i, i] = 0;
            }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (distances[i, k] == -1 || distances[k, j] == -1)
                            continue;

                        if (distances[i, j] == -1)
                            distances[i, j] = distances[i, k] + distances[k, j];

                        distances[i, j] = Math.Min(
                            distances[i, j],
                            distances[i, k] + distances[k, j]);
                    }
                }
            }

            return distances;
        }
    }

    public class SolutionDijkstraNoPriorityQueue
    {
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            // Initialize arrays of minimum distance & visited
            int[] dijkstra = Enumerable.Repeat(Int32.MaxValue, n + 1).ToArray();
            bool[] visited = new bool[n + 1];

            // Initialize the array of lists, which stores the direct neighbors for each node
            // and their distance to it
            List<(int, int)>[] neighbors = new List<(int, int)>[n + 1];
            for (int i = 1; i <= n; i++) neighbors[i] = new List<(int, int)>();
            foreach (int[] pair in times) neighbors[pair[0]].Add((pair[1], pair[2]));

            // We set the distance to the starting node as 0, and do Dijkstra's algorithm
            dijkstra[k] = 0;
            for (int i = 1; i <= n; i++)
            {
                // Since we don-t have a priority queue, we iterate to find the unvisited node
                // with the minimum possible distance
                int minDistance = Int32.MaxValue;
                int minIndex = -1;
                for (int j = 1; j <= n; j++)
                {
                    if (!visited[j] && dijkstra[j] < minDistance)
                    {
                        (minDistance, minIndex) = (dijkstra[j], j);
                    }
                }

                // If we didn't found a possible next candidate, we stop
                if (minIndex != -1)
                {
                    // We check if the using the direct path + minimum possible is better
                    // than the current distance
                    foreach ((int, int) pair in neighbors[minIndex])
                    {
                        (int to, int distance) = pair;
                        if (distance != Int32.MaxValue && minDistance != Int32.MaxValue)
                        {
                            dijkstra[to] = Math.Min(dijkstra[to], minDistance + distance);
                        }
                    }

                    visited[minIndex] = true;
                }
            }

            // We return the max of the dijkstra array
            int minimumTime = 0;
            for (int i = 1; i <= n; i++) minimumTime = Math.Max(minimumTime, dijkstra[i]);
            return (minimumTime == Int32.MaxValue) ? -1 : minimumTime;
        }
    }

    public class SolutionDijkstra
    {
        class State : IComparable<State>
        {
            public int Node { get; }
            public int Distance { get; }

            public State(int node, int distance)
            {
                Node = node;
                Distance = distance;
            }

            public int CompareTo(State other)
            {
                return Distance.CompareTo(other.Distance);
            }
        }

        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            k = k - 1;
            List<(int, int)>[] neighbors = new List<(int, int)>[n];
            for (int i = 0; i < n; i++)
                neighbors[i] = new List<(int, int)>();
            foreach (int[] pair in times)
                neighbors[pair[0] - 1].Add((pair[1] - 1, pair[2]));

            var queue = new PriorityQueue<State>();
            var seen = new int[n];
            for (int i = 0; i < n; i++)
                seen[i] = -1;

            queue.Enqueue(new State(k, 0));
            while (!queue.IsEmpty)
            {
                var curr = queue.DequeueMin();
                var currNode = curr.Node;

                if (seen[currNode] != -1)
                    continue;
                seen[currNode] = curr.Distance;

                foreach (var nextNodeTuple in neighbors[currNode])
                {
                    int nextNode = nextNodeTuple.Item1;
                    int distance = nextNodeTuple.Item2;

                    if (seen[nextNode] != -1)
                        continue;

                    int nextDistance = curr.Distance + distance;
                    queue.Enqueue(new State(nextNode, nextDistance));
                }
            }

            int max = -1;
            for (int i = 0; i < n; i++)
            {
                if (seen[i] == -1)
                    return -1;

                max = Math.Max(seen[i], max);
            }
            return max;
        }
    }
}

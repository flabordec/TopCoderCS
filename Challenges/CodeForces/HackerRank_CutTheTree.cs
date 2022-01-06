using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class Solution_CutTheTree
{

    /*
     * Complete the 'cutTheTree' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY data
     *  2. 2D_INTEGER_ARRAY edges
     */
    public static int CutTheTree(int[] data, HashSet<int>[] graph)
    {
        int[] parents = new int[data.Length];
        parents[0] = -1;

        bool[] seen = new bool[data.Length];
        long[] sums = new long[data.Length];

        Helper(0, parents, sums, data, seen, graph);

        int best = int.MaxValue;
        for (int i = 0; i < graph.Length; i++)
        {
            foreach (int j in graph[i])
            {
                if (i != parents[j])
                    continue;

                long sum = sums[0] - sums[j];
                int diff = (int)Math.Abs(sums[j] - sum);

                best = Math.Min(best, diff);
            }
        }
        return best;
    }

    public static void Helper(int curr, int[] parents, long[] sums, int[] data, bool[] seen, HashSet<int>[] graph)
    {
        seen[curr] = true;
        long sum = data[curr];

        foreach (int next in graph[curr])
        {
            if (!seen[next])
            {
                parents[next] = curr;
                Helper(next, parents, sums, data, seen, graph);
                sum += sums[next];
            }
        }

        sums[curr] = sum;
    }

    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int[] data = Console.ReadLine().TrimEnd().Split(' ').Select(dataTemp => Convert.ToInt32(dataTemp)).ToArray();

        var edges = new HashSet<int>[n];
        for (int i = 0; i < n; i++)
        {
            edges[i] = new HashSet<int>();
        }

        for (int i = 0; i < n - 1; i++)
        {
            var edge = Console.ReadLine().TrimEnd().Split(' ').Select(edgesTemp => Convert.ToInt32(edgesTemp)).ToArray();
            int from = edge[0] - 1;
            int to = edge[1] - 1;

            edges[from].Add(to);
            edges[to].Add(from);
        }

        int result = CutTheTree(data, edges);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();

    }
}
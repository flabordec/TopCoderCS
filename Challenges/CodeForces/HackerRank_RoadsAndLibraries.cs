using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class Solution_RoadsAndLibraries
{
    public static long roadsAndLibraries(int n, int c_lib, int c_road, int[][] cities)
    {
        if (c_lib <= c_road)
        {
            return (long)n * (long)c_lib;
        }

        bool[] seen = new bool[n];
        List<HashSet<int>> graph = new List<HashSet<int>>();
        for (int i = 0; i < n; i++)
        {
            graph.Add(new HashSet<int>());
        }

        for (int i = 0; i < cities.Length; i++)
        {
            int from = cities[i][0] - 1;
            int to = cities[i][1] - 1;
            graph[from].Add(to);
            graph[to].Add(from);
        }

        int libraries = 0;
        int roads = 0;
        for (int startIx = 0; startIx < n; startIx++)
        {
            if (!seen[startIx])
            {
                seen[startIx] = true;
                libraries++;

                var queue = new Queue<int>();
                queue.Enqueue(startIx);
                while (queue.Any())
                {
                    int curr = queue.Dequeue();

                    foreach (int next in graph[curr])
                    {
                        if (!seen[next])
                        {
                            seen[next] = true;
                            queue.Enqueue(next);
                            roads++;
                        }
                    }
                }
            }
        }
        return ((long)libraries * (long)c_lib) + ((long)roads * (long)c_road);
    }

    public static string roadsAndLibraries(string input)
    {
        StringBuilder output = new StringBuilder();
        StringReader reader = new StringReader(input);
        int q = Convert.ToInt32(reader.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] nmC_libC_road = reader.ReadLine().Split(' ');

            int n = Convert.ToInt32(nmC_libC_road[0]);

            int m = Convert.ToInt32(nmC_libC_road[1]);

            int c_lib = Convert.ToInt32(nmC_libC_road[2]);

            int c_road = Convert.ToInt32(nmC_libC_road[3]);

            int[][] cities = new int[m][];
            for (long i = 0; i < m; i++)
            {
                cities[i] = Array.ConvertAll(reader.ReadLine().Split(' '), citiesTemp => Convert.ToInt32(citiesTemp));
            }

            long result = roadsAndLibraries(n, c_lib, c_road, cities);

            output.AppendLine(result.ToString());
        }
        return output.ToString();
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] nmC_libC_road = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nmC_libC_road[0]);

            int m = Convert.ToInt32(nmC_libC_road[1]);

            int c_lib = Convert.ToInt32(nmC_libC_road[2]);

            int c_road = Convert.ToInt32(nmC_libC_road[3]);

            int[][] cities = new int[m][];
            for (long i = 0; i < m; i++)
            {
                cities[i] = Array.ConvertAll(Console.ReadLine().Split(' '), citiesTemp => Convert.ToInt32(citiesTemp));
            }

            long result = roadsAndLibraries(n, c_lib, c_road, cities);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}

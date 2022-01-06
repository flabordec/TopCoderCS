using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Runtime.InteropServices;

public class Solution_KingdomDivision
{
    // Complete the kingdomDivision function below.
    public static int KingdomDivision(int n, int[][] roads)
    {
        HashSet<int>[] graph = new HashSet<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new HashSet<int>();
        for (int i = 0; i < roads.Length; i++)
        {
            int from = roads[i][0] - 1;
            int to = roads[i][1] - 1;
            graph[from].Add(to);
            graph[to].Add(from);
        }

        int result = 0; 
        for (int colors = 0; colors < (1 << n); colors++)
        {
            bool war = false;
            for (int i = 0; i < n; i++)
            {
                int same = 0;
                int diff = 0;
                bool ci = (colors & (1 << i)) == 0;
                foreach (int j in graph[i])
                {
                    bool cj = (colors & (1 << j)) == 0;
                    if (ci == cj)
                    {
                        same++;
                    }
                    else
                    {
                        diff++;
                    }
                }

                if (diff > 0 && same == 0)
                {
                    war = true;
                    break;
                }
            }

            if (!war)
                result++;
        }
        return result;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[][] roads = new int[n - 1][];

        for (int i = 0; i < n - 1; i++)
        {
            roads[i] = Array.ConvertAll(Console.ReadLine().Split(' '), roadsTemp => Convert.ToInt32(roadsTemp));
        }

        int result = KingdomDivision(n, roads);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

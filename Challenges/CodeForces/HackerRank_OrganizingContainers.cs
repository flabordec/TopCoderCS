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

class Solution_OrganizingContainers
{

    // Complete the organizingContainers function below.
    static string OrganizingContainers(int[][] container)
    {
        // container[c][t] -- Balls of type t in container c

        // For each container
        var containerSizes = new int[container.Length];
        var ballCounts = new int[container.Length];
        for (int i = 0; i < container.Length; i++)
        {
            for (int j = 0; j < container.Length; j++)
            {
                containerSizes[i] += container[i][j];
                ballCounts[i] += container[j][i];
            }
        }

        Array.Sort(containerSizes);
        Array.Sort(ballCounts);
        return containerSizes.SequenceEqual(ballCounts) ? "Possible" : "Impossible";
    }

    static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[][] container = new int[n][];

            for (int i = 0; i < n; i++)
            {
                container[i] = Array.ConvertAll(Console.ReadLine().Split(' '), containerTemp => Convert.ToInt32(containerTemp));
            }

            string result = OrganizingContainers(container);

            Console.WriteLine(result);
        }
        Console.ReadLine();
    }
}
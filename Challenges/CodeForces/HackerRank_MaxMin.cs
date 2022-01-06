using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class Solution_MaxMin
{
    // Complete the maxMin function below.
    static int maxMin(int k, int[] arr)
    {
        Array.Sort(arr);
        int best = int.MaxValue;
        for (int i = 0; i < arr.Length - k + 1; i++)
        {
            int curr = arr[i + k - 1] - arr[i];
            best = Math.Min(curr, best);
        }
        return best;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int k = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            int arrItem = Convert.ToInt32(Console.ReadLine());
            arr[i] = arrItem;
        }

        int result = maxMin(k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
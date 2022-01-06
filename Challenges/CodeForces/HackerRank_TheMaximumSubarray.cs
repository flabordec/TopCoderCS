using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

public class Solution_TheMaximumSubarray
{
    // Complete the maxSubarray function below.
    public static int[] maxSubarray(int[] arr)
    {
        int maximum = int.MinValue;
        int sumOfPositives = 0;
        int bestSum = 0;
        int[] bestSums = new int[arr.Length];
        bestSums[0] = Math.Max(arr[0], 0);
        for (int i = 1; i < arr.Length; i++)
        {
            if ( bestSums[i - 1] + arr[i] > 0)
            {
                bestSums[i] = bestSums[i - 1] + arr[i];
            }
            else
            {
                bestSums[i] = 0;
            }
            bestSum = Math.Max(bestSums[i], bestSum);
        }
        for (int i = 0; i < arr.Length; i++)
        {
            maximum = Math.Max(arr[i], maximum);
            if (arr[i] > 0)
                sumOfPositives += arr[i];
        }

        int bestSubSequence = sumOfPositives > 0 ? sumOfPositives : maximum;
        int bestSubArray = bestSum > 0 ? bestSum : maximum;

        return new int[] { bestSubArray, bestSubSequence };
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            int[] result = maxSubarray(arr);

            textWriter.WriteLine(string.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }

}

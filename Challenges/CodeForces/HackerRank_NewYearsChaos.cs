using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

class Solution_NewYearsChaos
{
    // Complete the minimumBribes function below.
    static int minimumBribes(int[] q)
    {
        int[] bribes = new int[q.Length];
        int totalSwaps = 0;
        int[] diffs = new int[q.Length];
        for (int i = 0; i < q.Length - 1; i++)
        {
            int swaps = 0;
            for (int j = 0; j < q.Length - i - 1; j++)
            {
                if (q[j] > q[j + 1])
                {
                    bribes[q[j] - 1]++;
                    if (bribes[q[j] - 1] > 2)
                        return -1;

                    int temp = q[j];
                    q[j] = q[j + 1];
                    q[j + 1] = temp;
                    swaps++;
                    totalSwaps++;
                }
            }

            if (swaps == 0)
                break;
        }

        return totalSwaps;
    }

    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp));

            int bribes = minimumBribes(q);
            if (bribes == -1)
            {
                Console.WriteLine("Too chaotic");
            }
            else
            {
                Console.WriteLine(bribes);
            }
        }
    }

}

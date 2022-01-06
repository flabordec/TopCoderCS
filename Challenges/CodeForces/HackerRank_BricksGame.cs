using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class Solution_BricksGame
{
    public static int BricksGame(int[] arr)
    {
        return Solve(arr, 0, true, 0);
    }

    static int Solve(int[] arr, int ix, bool player1, int sum1)
    {
        if (ix == arr.Length)
        {
            return sum1;
        }

        int best = player1 ? 0 : int.MaxValue;
        int currSum = sum1;
        for (int i = 0; i < 3; i++)
        {
            int nix = ix + i;
            if (nix == arr.Length)
                break;

            if (player1)
            {
                currSum += arr[nix];
                best = Math.Max(best, Solve(arr, nix + 1, !player1, currSum));
            } 
            else
            {
                best = Math.Min(best, Solve(arr, nix + 1, !player1, currSum));
            }
        }
        return best;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int arrCount = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int result = BricksGame(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}

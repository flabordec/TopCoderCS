using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GoogleInterviewKnight
{
    public int CalculateKnight(int N)
    {
        int[][] nextNodes = new[]
        {
                /*0*/ new int[] {4, 6},
                /*1*/ new int[] {6, 8},
                /*2*/ new int[] {7, 9},
                /*3*/ new int[] {4, 8},
                /*4*/ new int[] {3, 9, 0},
                /*5*/ new int[] { },
                /*6*/ new int[] {1, 7, 0},
                /*7*/ new int[] {2, 6},
                /*8*/ new int[] {1, 3},
                /*9*/ new int[] {4, 2},
            };

        int[][] dp = new int[10][];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[N];
            dp[i][0] = 1;
        }

        for (int numJumps = 1; numJumps < N; numJumps++)
        {
            for (int n = 0; n < 10; n++)
            {
                foreach (int next in nextNodes[n])
                {
                    dp[n][numJumps] += dp[next][numJumps - 1];
                }
            }
        }

        for (int numJumps = 1; numJumps < N; numJumps++)
        {
            Console.WriteLine($"With {numJumps} jumps");
            for (int n = 0; n < 10; n++)
            {
                Console.Write(dp[n][numJumps] + "\t");
            }

            Console.WriteLine();
        }

        return 0;
    }
}

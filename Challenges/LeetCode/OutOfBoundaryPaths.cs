using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.OutOfBoundaryPaths
{
    public class Solution
    {
        public static int[] dr = new[] { 1, -1, 0, 0 };
        public static int[] dc = new[] { 0, 0, 1, -1 };

        public int FindPaths(int rows, int cols, int maxMove, int startRow, int startColumn)
        {
            int mod = 1000000007;

            if (maxMove == 0)
                return 0;

            int[,,] dp = new int[rows, cols, 2];

            for (int j = 0; j < cols; j++)
            {
                dp[0, j, 0] += 1;
                dp[rows - 1, j, 0] += 1;
            }

            for (int i = 0; i < rows; i++)
            {
                dp[i, 0, 0] += 1;
                dp[i, cols - 1, 0] += 1;
            }
            PrintArray(0, rows, cols, 0, dp);

            int sum = dp[startRow, startColumn, 0];
            for (int move = 1; move < maxMove; move++)
            {
                int pm = ~move & 1;
                int cm = move & 1;

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        dp[r, c, cm] = 0;
                        for (int d = 0; d < dr.Length; d++)
                        {
                            int nr = r + dr[d];
                            int nc = c + dc[d];

                            if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                                continue;

                            dp[r, c, cm] = (dp[r, c, cm] + dp[nr, nc, pm]) % mod;
                        }
                    }
                }

                sum = (sum + dp[startRow, startColumn, cm]) % mod;
                PrintArray(move, rows, cols, cm, dp);
            }

            return sum;
        }

        public int FindPathsOriginal(int rows, int cols, int maxMove, int startRow, int startColumn)
        {
            int mod = 1000000007;

            if (maxMove == 0)
                return 0;

            int[,,] dp = new int[rows, cols, maxMove];

            for (int j = 0; j < cols; j++)
            {
                dp[0, j, 0] += 1;
                dp[rows - 1, j, 0] += 1;
            }

            for (int i = 0; i < rows; i++)
            {
                dp[i, 0, 0] += 1;
                dp[i, cols - 1, 0] += 1;
            }
            PrintArray(0, rows, cols, 0, dp);

            for (int move = 1; move < maxMove; move++)
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        for (int d = 0; d < dr.Length; d++)
                        {
                            int nr = r + dr[d];
                            int nc = c + dc[d];

                            if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                                continue;

                            dp[r, c, move] = (dp[r, c, move] + dp[nr, nc, move - 1]) % mod;
                        }
                    }
                }
                PrintArray(move, rows, cols, move, dp);
            }

            int sum = 0;
            for (int move = 0; move < maxMove; move++)
            {
                sum = (sum + dp[startRow, startColumn, move]) % mod;
            }
            return sum;
        }

        void PrintArray(int move, int rows, int cols, int cm, int[,,] dp)
        {
            Console.WriteLine($"Move = {move}");
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(dp[r, c, cm] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

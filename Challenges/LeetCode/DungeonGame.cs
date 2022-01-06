using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.DungeonGame
{
    public class Solution
    {
        public int CalculateMinimumHP(int[][] dungeon)
        {
            int?[][] dp = new int?[dungeon.Length][];
            for (int i = 0; i < dungeon.Length; i++)
            {
                dp[i] = new int?[dungeon[i].Length];
            }
            return Calculate(dp, dungeon, 0, 0);
        }

        public int Calculate(int?[][] dp, int[][] dungeon, int i, int j)
        {
            if (dp[i][j] == null)
            {
                if (i == dungeon.Length - 1 && j == dungeon[i].Length - 1)
                {
                    dp[i][j] = dungeon[i][j] > 0 ? 1 : -dungeon[i][j] + 1;
                }
                else if (i == dungeon.Length - 1)
                {
                    dp[i][j] = Math.Max(1, Calculate(dp, dungeon, i, j + 1) - dungeon[i][j]);
                }
                else if (j == dungeon[i].Length - 1)
                {
                    dp[i][j] = Math.Max(1, Calculate(dp, dungeon, i + 1, j) - dungeon[i][j]);
                }
                else
                {
                    dp[i][j] = Math.Max(
                        1,
                        Math.Min(
                            Calculate(dp, dungeon, i + 1, j) - dungeon[i][j],
                            Calculate(dp, dungeon, i, j + 1) - dungeon[i][j]));
                }
            }
            return dp[i][j].Value;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.BrickWall
{
    // |[][]| -> 1   3   5 
    // [ ]|[] ->     3 4 
    // |[ ][] -> 1     4 
    // [][  ] ->   2 
    // [ ]|[] ->     3 4
    // |[ ]|| -> 1     4 5

    public class Solution
    {
        public int LeastBricks(IList<IList<int>> wall)
        {
            var columnCounts = new Dictionary<int, int>();

            for (int i = 0; i < wall.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < wall[i].Count - 1; j++)
                {
                    sum += wall[i][j];
                    if (!columnCounts.ContainsKey(sum))
                        columnCounts.Add(sum, 0);
                    columnCounts[sum]++;
                }
            }

            if (columnCounts.Any())
            {
                int max = columnCounts.Values.Max();
                return wall.Count - max;
            }
            else
            {
                return wall.Count;
            }
        }
    }

    public class SolutionMaxInPlace
    {
        public int LeastBricks(IList<IList<int>> wall)
        {
            var columnCounts = new Dictionary<int, int>();

            int max = 0;
            for (int i = 0; i < wall.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < wall[i].Count - 1; j++)
                {
                    sum += wall[i][j];
                    if (!columnCounts.ContainsKey(sum))
                        columnCounts.Add(sum, 0);
                    columnCounts[sum]++;
                    max = Math.Max(max, columnCounts[sum]);
                }
            }

            return wall.Count - max;
        }
    }

}

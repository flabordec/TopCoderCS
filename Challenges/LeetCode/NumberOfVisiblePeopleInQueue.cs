using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.NumberOfVisiblePeopleInQueue
{
    public class Solution
    {
        public int[] CanSeePersonsCount(int[] heights)
        {
            int[] canSeeCounts = new int[heights.Length];

            var taller = new Stack<int>();
            taller.Push(heights.Last());

            for (int i = heights.Length - 2; i >= 0; i--)
            {
                int canSeeCount = 0;
                while (taller.Any() && heights[i] > taller.Peek())
                {
                    canSeeCount++;
                    taller.Pop();
                }

                if (taller.Any())
                {
                    canSeeCount++;
                }

                taller.Push(heights[i]);

                canSeeCounts[i] = canSeeCount;
            }

            return canSeeCounts;
        }
    }

    public class SolutionNSquared
    {
        public int[] CanSeePersonsCount(int[] heights)
        {
            int[] maxHeightsInRange = new int[heights.Length];
            int[] canSeeCount = new int[heights.Length];

            for (int i = 0; i < heights.Length - 1; i++)
            {
                int maxHeight = heights[i + 1];

                maxHeightsInRange[i + 1] = maxHeight;

                canSeeCount[i]++;
                for (int j = i + 2; j < heights.Length; j++)
                {
                    maxHeight = Math.Max(maxHeight, heights[j]);
                    maxHeightsInRange[j] = maxHeight;

                    int minHeight = Math.Min(heights[i], heights[j]);
                    int maxHeightInRange = maxHeightsInRange[j - 1];

                    if (minHeight > maxHeightInRange)
                        canSeeCount[i]++;

                    if (heights[j] >= heights[i])
                        break;
                }
            }

            return canSeeCount;
        }
    }
}

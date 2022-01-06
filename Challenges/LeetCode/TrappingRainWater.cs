using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.TrappingRainWater
{
    public class Solution
    {
        public int Trap(int[] height)
        {
            int[] water = new int[height.Length];
            int previousWallIx;

            previousWallIx = 0;
            for (int i = 1; i < height.Length; i++)
            {
                if (height[i] >= height[previousWallIx])
                {
                    for (int j = previousWallIx + 1; j < i; j++)
                    {
                        water[j] = Math.Max(
                            water[j],
                            height[previousWallIx] - height[j]);
                    }
                    previousWallIx = i;
                }
            }

            previousWallIx = height.Length - 1;
            for (int i = height.Length - 2; i >= 0; i--)
            {
                if (height[i] >= height[previousWallIx])
                {
                    for (int j = previousWallIx - 1; j > i; j--)
                    {
                        water[j] = Math.Max(
                            water[j],
                            height[previousWallIx] - height[j]);
                    }
                    previousWallIx = i;
                }
            }

            return water.Sum();
        }
    }
}

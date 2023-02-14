using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.CountOddNumbersInAnIntervalRange
{
    public class Solution
    {
        public int CountOdds(int low, int high)
        {
            if (high == low)
            {
                return ((low & 1) != 0) ? 1 : 0;
            }

            if ((low & 1) == 0)
                low++;

            if ((high & 1) != 0)
                high++;

            return (high - low + 1) / 2;
        }
    }
}

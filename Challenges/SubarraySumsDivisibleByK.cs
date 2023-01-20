using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubarraySumsDivisibleByK
{
    public class Solution
    {
        public int SubarraysDivByKRemaindersArray(int[] nums, int k)
        {
            int count = 0;
            int runningSum = 0;
            var remainderCount = new int[k];
            remainderCount[0] = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                runningSum += nums[i];
                int remainder = (runningSum % k + k) % k;
                count += remainderCount[remainder];
                remainderCount[remainder]++;
            }
            return count;
        }

        public int SubarraysDivByKRemaindersDict(int[] nums, int k)
        {
            int count = 0;
            int runningSum = 0;
            var remainderCount = new Dictionary<int, int>();
            remainderCount.Add(0, 1);
            for (int i = 0; i < nums.Length; i++)
            {
                runningSum += nums[i];
                int remainder = (runningSum % k + k) % k;
                if (remainderCount.ContainsKey(remainder))
                {
                    count += remainderCount[remainder];
                }
                else
                {
                    remainderCount.Add(remainder, 0);
                }

                remainderCount[remainder]++;
            }
            return count;
        }

        public int SubarraysDivByKForLoops(int[] nums, int k)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if (sum % k == 0)
                        count++;
                }
            }

            return count;
        }
    }
}

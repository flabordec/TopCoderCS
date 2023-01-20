using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonDecreasingSubsequences
{
    public class Solution
    {
        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            var results = new List<IList<int>>();
            var alreadyAttempted = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var tempResult = new List<int>();
                if (alreadyAttempted.Add(nums[i]))
                    FindSubsequencesHelper(nums, i, results, tempResult);
            }

            return results;
        }

        private void FindSubsequencesHelper(int[] nums, int ix, IList<IList<int>> results, IList<int> result)
        {
            if (ix == nums.Length)
                return;

            if (!result.Any() || nums[ix] >= result.Last())
            {
                var newResult = new List<int>();
                newResult.AddRange(result);
                newResult.Add(nums[ix]);

                if (newResult.Count > 1)
                    results.Add(newResult);

                var alreadyAttempted = new HashSet<int>();
                for (int nIx = ix + 1; nIx < nums.Length; nIx++)
                {
                    if (alreadyAttempted.Add(nums[nIx]))
                        FindSubsequencesHelper(nums, nIx, results, newResult);
                }
            }
        }
    }

}

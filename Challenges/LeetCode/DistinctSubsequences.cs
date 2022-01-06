using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.DistinctSubsequences
{
    public class Solution
    {
        public int NumDistinct(string s, string t)
        {
            int[,] cache = new int[s.Length + 1, t.Length + 1];
            for (int i = 0; i < s.Length + 1; i++)
                for (int j = 0; j < t.Length + 1; j++)
                    cache[i, j] = -1;

            int result = Solve(s, t, 0, 0, cache);
            return result;
        }

        public int Solve(string s, string t, int ixS, int ixT, int[,] cache)
        {
            if (cache[ixS, ixT] == -1)
            {
                if (ixT == t.Length)
                {
                    cache[ixS, ixT] = 1;
                }
                else if (ixS == s.Length)
                {
                    cache[ixS, ixT] = 0;
                }
                else
                {
                    cache[ixS, ixT] = 0;
                    if (s[ixS] == t[ixT])
                    {
                        cache[ixS, ixT] += Solve(s, t, ixS + 1, ixT + 1, cache);
                    }
                    cache[ixS, ixT] += Solve(s, t, ixS + 1, ixT, cache);
                }
            }
            return cache[ixS, ixT];
        }
    }

}

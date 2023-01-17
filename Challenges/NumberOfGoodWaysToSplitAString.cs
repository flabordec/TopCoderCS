using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfGoodWaysToSplitAString
{
    public class Solution
    {
        public int NumSplits(string s)
        {
            Dictionary<char, int> left = new Dictionary<char, int>();
            Dictionary<char, int> right = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!right.ContainsKey(s[i]))
                    right.Add(s[i], 0);
                right[s[i]]++;
            }

            int goodStrings = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (!left.ContainsKey(s[i]))
                    left.Add(s[i], 0);
                left[s[i]]++;

                right[s[i]]--;
                if (right[s[i]] == 0)
                    right.Remove(s[i]);

                if (left.Count == right.Count)
                {
                    goodStrings++;
                }
            }

            return goodStrings;
        }
    }
}

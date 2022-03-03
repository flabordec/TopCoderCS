using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.LengthOfLongestSubstring
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var indicesPerLetter = new Dictionary<char, List<int>>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (!indicesPerLetter.ContainsKey(c))
                    indicesPerLetter.Add(c, new List<int>());
                indicesPerLetter[c].Add(i);
            }

            var nextIndexPerLetter = new Dictionary<char, Dictionary<int, int>>();
            foreach (char c in indicesPerLetter.Keys)
            {
                nextIndexPerLetter.Add(c, new Dictionary<int, int>());
                for (int i = 0; i < indicesPerLetter[c].Count - 1; i++)
                {
                    int ci = indicesPerLetter[c][i];
                    int ni = indicesPerLetter[c][i + 1];
                    nextIndexPerLetter[c].Add(ci, ni);
                }
                int li = indicesPerLetter[c].Count - 1;
                nextIndexPerLetter[c].Add(indicesPerLetter[c][li], -1);
            }

            Console.WriteLine(nextIndexPerLetter);

            int[] maxLengths = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                int ci = i;
                int ni = nextIndexPerLetter[c][i];

                if (ni == -1)
                {
                    maxLengths[i] = s.Length - ci;
                }
                else
                {
                    maxLengths[i] = ni - ci;
                }
            }
            Console.WriteLine(maxLengths);

            int best = 0;
            for (int i = 0; i < maxLengths.Length; i++)
            {
                int length = maxLengths[i];
                int remainingLength = length;

                int actualLength = 1;
                remainingLength--;
                while (remainingLength > 0)
                {
                    int currCharIx = i + actualLength;
                    int maxLengthCurrentChar = maxLengths[currCharIx];

                    if (maxLengthCurrentChar < remainingLength)
                    {
                        remainingLength = maxLengthCurrentChar;
                    }
                    remainingLength--;
                    actualLength++;
                }

                Console.WriteLine($"Valid case: {i}, length: {actualLength}");
                best = Math.Max(best, actualLength);
            }

            return best;
        }
    }

}

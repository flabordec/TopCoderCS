using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemovingStarsFromAString
{
    public class Solution
    {
        public string RemoveStars(string s)
        {
            var sOut = new char[s.Length];
            int ix = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '*')
                {
                    if (ix > 0)
                        ix--;
                }
                else
                {
                    sOut[ix] = s[i];
                }
            }
            return new string(sOut, 0, ix);
        }

        public string RemoveStarsList(string s)
        {
            var sOut = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '*')
                {
                    if (sOut.Any())
                        sOut.RemoveAt(sOut.Count - 1);
                }
                else
                {
                    sOut.Add(s[i]);
                }
            }
            return new string(sOut.ToArray());
        }
    }
}

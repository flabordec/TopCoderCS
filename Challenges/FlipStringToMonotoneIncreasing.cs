using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipStringToMonotoneIncreasing
{
    public class Solution
    {
        public int MinFlipsMonoIncr(string s)
        {
            bool counting = false;
            int counter = 0;
            int flips = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1')
                    counting = true;

                if (counting)
                {
                    if (s[i] == '1')
                        counter++;
                    else
                        flips++;

                    flips = Math.Min(flips, counter);
                }
            }

            return flips;
        }
    }
}

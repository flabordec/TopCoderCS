using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.AddBinary
{
    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            var sb = new StringBuilder();
            int length = Math.Max(a.Length, b.Length);

            bool carry = false;
            for (int i = 0; i < length; i++)
            {
                char c1 = i < a.Length ? a[a.Length - i - 1] : '0';
                char c2 = i < b.Length ? b[b.Length - i - 1] : '0';

                if (carry)
                {
                    if (c1 == '1' && c2 == '1')
                    {
                        carry = true;
                        sb.Insert(0, '1');
                    }
                    else if (
                        c1 == '1' && c2 == '0' ||
                        c1 == '0' && c2 == '1')
                    {
                        carry = true;
                        sb.Insert(0, '0');
                    }
                    else
                    {
                        carry = false;
                        sb.Insert(0, '0');
                    }
                }
                else
                {
                    if (c1 == '1' && c2 == '1')
                    {
                        carry = true;
                        sb.Insert(0, '0');
                    }
                    else if (
                        c1 == '1' && c2 == '0' ||
                        c1 == '0' && c2 == '1')
                    {
                        carry = false;
                        sb.Insert(0, '1');
                    }
                    else
                    {
                        carry = false;
                        sb.Insert(0, '0');
                    }
                }
            }
            if (carry)
            {
                sb.Insert(0, '1');
            }
            return sb.ToString();
        }
    }
}

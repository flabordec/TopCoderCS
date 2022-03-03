using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    public class KDoubleSubstrings
    {
		public int howMuch(string[] str, int k)
		{
			string s = string.Join("", str);
			int total = 0;

			for (int len = 2; len <= s.Length; len += 2)
			{
				for (int i = 0; i <= s.Length - len; i++)
				{
					if (IsKString(s.Substring(i, len), k))
						total++;
				}
			}
			return total;
		}

		public bool IsKString(string s, int k)
		{
			int diffs = 0;
			int sLength2 = s.Length / 2;
			for (int i = 0; i < sLength2; i++)
			{
				if (s[i] != s[sLength2 + i])
					diffs++;

				if (diffs > k)
					return false;
			}
			return true;
		}
    }
}

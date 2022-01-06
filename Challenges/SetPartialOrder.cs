using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

	class SetPartialOrder
	{
		public string compareSets(int[] a, int[] b)
		{
			HashSet<int> aSet = new HashSet<int>(a);
			HashSet<int> bSet = new HashSet<int>(b);
			if (aSet.SetEquals(b))
			{
				return "EQUAL";
			}
			else if (aSet.IsProperSubsetOf(bSet))
			{
				return "LESS";
			}
			else if (bSet.IsProperSubsetOf(aSet))
			{
				return "GREATER";
			}
			else
			{
				return "INCOMPARABLE";
			}
		}
	}


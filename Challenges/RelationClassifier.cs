using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RelationClassifier
{
	public string isBijection(int[] domain, int[] range)
	{
		HashSet<int> countsDomain = new HashSet<int>();
		for (int i = 0; i < domain.Length; i++)
		{
			if (countsDomain.Contains(domain[i]))
				return "Not";
			countsDomain.Add(domain[i]);
		}

		HashSet<int> countsRange = new HashSet<int>();
		for (int i = 0; i < range.Length; i++)
		{
			if (countsRange.Contains(range[i]))
				return "Not";
			countsRange.Add(range[i]);
		}

		return "Bijection";
	}
}

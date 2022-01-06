using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SandwichBar
{
	public int whichOrder(string[] available, string[] orders)
	{
		HashSet<string> availableSet = new HashSet<string>(available);
		for (int i = 0; i < orders.Length; i++)
		{
			string[] ingredients = orders[i].Split(' ');
			if (ingredients.All(ing => availableSet.Contains(ing)))
				return i;
		}
		return -1;
	}
}

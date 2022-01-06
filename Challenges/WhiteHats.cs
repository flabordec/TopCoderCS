using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WhiteHats
{
	public int whiteNumber(int[] count)
	{
		var values = new Dictionary<int, int>();
		foreach (int i in count)
		{
			if (!values.ContainsKey(i))
				values.Add(i, 0);
			values[i]++;
		}

		if (values.Count >= 3)
			return -1;

		Console.WriteLine("Values {0}", string.Join(",", values));
		int whiteHats = values.Keys.Max();
		int blackHats = values.Keys.Min();
		
		Console.WriteLine("White hats {0}, Black hats {1}", whiteHats, blackHats);
		Console.WriteLine("Num white hats {0}", values[blackHats]);
		if (values.Count == 1)
		{
			if (whiteHats == 0)
				return 0;
			else if (whiteHats == count.Length - 1)
				return whiteHats + 1;
			else
				return -1;
		}
		else if (values.Count == 2)
		{
			if (whiteHats != blackHats + 1)
				return -1;
			if (whiteHats == values[blackHats])
				return whiteHats;
			else 
				return -1;
		}
		else
			return -1;
	}
}


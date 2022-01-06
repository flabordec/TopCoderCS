using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TileCutting
{
	public int cuts(string[] layout)
	{
		int singles = 0;
		int doubles = 0;
		int triples = 0;

		for (int i = 0; i < layout.Length; i += 2)
		{
			for (int j = 0; j < layout[i].Length; j += 2)
			{
				int count = 0;
				if (layout[i][j] == '.')
					count++;
				if (layout[i + 1][j] == '.')
					count++;
				if (layout[i][j + 1] == '.')
					count++;
				if (layout[i + 1][j + 1] == '.')
					count++;

				if (count == 1)
					singles++;
				else if (count == 2)
				{
					if (layout[i][j] == layout[i][j + 1] || layout[i][j] == layout[i + 1][j])
						doubles++;
					else
						singles += 2;
				}
				else if (count == 3)
					triples++;
			}
		}

		int cuts = 0;
		Console.WriteLine();
		Console.WriteLine("Singles: {0}, Doubles {1}, Triples {2}, Cuts {3}", singles, doubles, triples, cuts);
		while (triples > 0)
		{
			if (singles <= -3)
			{
				triples--;
				singles += 3;
			}
			else
			{
				triples--;
				singles--;
				cuts += 2;
			}
		}
		Console.WriteLine("Singles: {0}, Doubles {1}, Triples {2}, Cuts {3}", singles, doubles, triples, cuts);
		while (doubles > 0)
		{
			if (singles <= -2)
			{
				doubles--;
				singles += 2;
			}
			else
			{
				doubles -= 2;
				cuts += 2;
			}
		}
		Console.WriteLine("Singles: {0}, Doubles {1}, Triples {2}, Cuts {3}", singles, doubles, triples, cuts);
		while (singles > 0)
		{
			if (doubles < 0)
			{
				singles -= 2;
				doubles++;
				cuts++;
			}
			else if (singles >= 3)
			{
				singles -= 4;
				cuts += 4;
			}
			else if (singles >= 2)
			{
				singles -= 2;
				doubles--;
				cuts += 3;
			}
			else
			{
				singles--;
				triples--;
				cuts += 2;
			}
		}
		Console.WriteLine("Singles: {0}, Doubles {1}, Triples {2}, Cuts {3}", singles, doubles, triples, cuts);

		return cuts;
	}
}
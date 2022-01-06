using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Xylophone
{
	public int countKeys(int[] keys)
	{
		HashSet<int> notes = new HashSet<int>();
		foreach (int key in keys)
		{
			notes.Add((key - 1) % 7);
		}
		return notes.Count;
	}
}

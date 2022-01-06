using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OmegaUp_SemiconductorTestSystem
{
	static void Main(string[] args)
	{
		int t4 = int.Parse(Console.ReadLine());
		int t1 = int.Parse(Console.ReadLine());

		int f = int.Parse(Console.ReadLine());
		int[] p = new int[f];
		for (int i = 0; i < f; i++)
			p[i] = int.Parse(Console.ReadLine());

		int devicesNeeded = CountDevices(p, t4, t1);
		Console.WriteLine(devicesNeeded);
	}

	public static int CountDevices(int[] production, int t4, int t1)
	{
		int minT1s = int.MaxValue;
		for (int i = 0; i < production.Length; i++)
		{
			int currT1s = 0;
			int left = production[i] - t4;
			if (left > 0)
			{
				currT1s += (int)Math.Ceiling((double)left / t1);
			}
			for (int j = 0; j < production.Length; j++)
			{
				if (j == i)
					continue;
				currT1s += (int)Math.Ceiling((double)production[j] / t1);
			}
			minT1s = Math.Min(currT1s, minT1s);
		}
		return minT1s;
	}
}
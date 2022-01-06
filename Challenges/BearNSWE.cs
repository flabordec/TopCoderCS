using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BearNSWE
{
	public double totalDistance(int[] a, string dir)
	{
		int totalDistance = 0;
		int x = 0;
		int y = 0;

		for (int i = 0; i < a.Length; i++)
		{
			int distance = a[i];
			char direction = dir[i];

			switch (direction)
			{
				case 'N':
					y += distance;
					break;
				case 'S':
					y -= distance;
					break;
				case 'E':
					x += distance;
					break;
				case 'W':
					x -= distance;
					break;
			}
			totalDistance += distance;
		}
		Console.WriteLine(totalDistance);
		Console.WriteLine("{0}, {1}", x, y);
		return Math.Sqrt((x * x) + (y * y)) + totalDistance;
	}
}
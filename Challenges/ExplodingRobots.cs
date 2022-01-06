using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExplodingRobots
{
	public string canExplode(int x1, int y1, int x2, int y2, string instructions)
	{
		int minX1 = x1;
		int maxX1 = x1;
		int minY1 = y1;
		int maxY1 = y1;

		int minX2 = x2;
		int maxX2 = x2;
		int minY2 = y2;
		int maxY2 = y2;

		for (int i = 0; i < instructions.Length; i++)
		{
			switch (instructions[i])
			{
				case 'U':
					maxY1++;
					maxY2++;
					break;
				case 'D':
					minY1--;
					minY2--;
					break;
				case 'R':
					maxX1++;
					maxX2++;
					break;
				case 'L':
					minX1--;
					minX2--;
					break;
			}
		}

		Console.WriteLine("x: {0}, {1} -- y: {0}, {1}", minX1, maxX1, minY1, maxY1);
		Console.WriteLine("x: {0}, {1} -- y: {0}, {1}", minX2, maxX2, minY2, maxY2);

		if (minX1 <= maxX2 && maxX1 >= minX2 && minY1 <= maxY2 && maxY1 >= minY2)
			return "Explosion";
		else
			return "Safe";


	}
}

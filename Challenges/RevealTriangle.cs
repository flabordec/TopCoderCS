using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RevealTriangle
{
	public string[] calcTriangle(string[] questionMarkTriangle)
	{
		StringBuilder[] lines = new StringBuilder[questionMarkTriangle.Length];
		for (int i = 0; i < questionMarkTriangle.Length; i++)
		{
			lines[i] = new StringBuilder(questionMarkTriangle[i]);
		}

		for (int i = lines.Length - 2; i >= 0; i--)
		{
			for (int k = 0; k < lines[i].Length; k++)
			{
				bool done = true;
				for (int j = 0; j < lines[i].Length; j++)
				{
					if (lines[i][j] != '?')
					{
						if (j > 0 && lines[i][j - 1] == '?')
						{
							lines[i][j - 1] = CalcValue(lines[i + 1][j - 1], lines[i][j]);
						}
						if (j < lines[i].Length - 1 && lines[i][j + 1] == '?')
						{
							lines[i][j + 1] = CalcValue(lines[i + 1][j], lines[i][j]);
						}
					}
					else
					{
						done = false;
					}
				}
				if (done)
					break;
			}
			Console.WriteLine("Orig: {0}\nNew:  {1}", questionMarkTriangle[i], lines[i].ToString());
			Console.WriteLine();
		}

		var array = (
			from line in lines
			select line.ToString()
			).ToArray();
		return array;
	}

	private static char CalcValue(char childC, char parentC)
	{
		int child = childC - '0';
		int parent = parentC - '0';

		if (child < parent)
			child += 10;
		child = (child - parent) % 10;
		return (char)(child + '0');
	}
}
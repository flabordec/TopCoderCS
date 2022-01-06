using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

class Solution_Candies
{
	static void Main(String[] args)
	{
		int n = int.Parse(Console.ReadLine());
		int[] grades = new int[n];
		int[] candy = new int[n];
		for (int i = 0; i < n; i++)
		{
			grades[i] = int.Parse(Console.ReadLine());
			candy[i] = 1;
		}

		for (int k = 0; k < n; k++)
		{
			bool changes = false;
			for (int i = 0; i < n; i++)
			{
				if (i > 0)
				{
					if (grades[i] > grades[i - 1])
					{
						if (candy[i - 1] + 1 > candy[i])
						{
							candy[i] = candy[i - 1] + 1;
							changes = true;
						}
					}
				}
				if (i < n - 1)
				{
					if (grades[i] > grades[i + 1])
					{
						if (candy[i + 1] + 1 > candy[i])
						{
							candy[i] = candy[i + 1] + 1;
							changes = true;
						}
					}
				}
			}
			// optimized garbage FTW! The worst case scenario is a grades array sorted backwards: 
			// 5 4 3 2 1, in that case, the single for loop case will modify one value at a time. 
			// Adding the second for loop will get around this case.
			for (int i = n - 1; i >= 0; i--)
			{
				if (i > 0)
				{
					if (grades[i] > grades[i - 1])
					{
						if (candy[i - 1] + 1 > candy[i])
						{
							candy[i] = candy[i - 1] + 1;
							changes = true;
						}
					}
				}
				if (i < n - 1)
				{
					if (grades[i] > grades[i + 1])
					{
						if (candy[i + 1] + 1 > candy[i])
						{
							candy[i] = candy[i + 1] + 1;
							changes = true;
						}
					}
				}
			}
			if (!changes)
				break;
		}

		// Console.Error.WriteLine(string.Join(", ", candy));
		long sum = 0;
		for (int i = 0; i < n; i++)
			sum += candy[i];
		Console.WriteLine(sum);
	}

}

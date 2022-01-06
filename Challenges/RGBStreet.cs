using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RGBStreet
{
	public int estimateCost(string[] houses)
	{
		int[,] dp = new int[3, houses.Length];
		SplitHouse(houses, dp, 0);
		for (int i = 1; i < houses.Length; i++)
		{
			SplitHouse(houses, dp, i);
			dp[0, i] += Math.Min(dp[1, i - 1], dp[2, i - 1]);
			dp[1, i] += Math.Min(dp[0, i - 1], dp[2, i - 1]);
			dp[2, i] += Math.Min(dp[0, i - 1], dp[1, i - 1]);

			Print(dp);
		}
		int result = dp[0, houses.Length - 1];
		result = Math.Min(result, dp[1, houses.Length - 1]);
		result = Math.Min(result, dp[2, houses.Length - 1]);
		return result;
	}

	private void Print(int[,] dp)
	{
		Console.WriteLine("------------------");
		for (int i = 0; i < dp.GetLength(0); i++)
		{
			for (int j = 0; j < dp.GetLength(1); j++)
			{
				Console.Write(dp[i, j] + " ");
			}
			Console.WriteLine();
		}
	}

	private void SplitHouse(string[] houses, int[,] dp, int i)
	{
		string house = houses[i];
		string[] houseSplit = house.Split(' ');
		for (int j = 0; j < 3; j++)
			dp[j, i] = int.Parse(houseSplit[j]);
	}
}

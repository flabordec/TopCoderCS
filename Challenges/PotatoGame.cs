using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PotatoGame
{
	public string theWinner(int n)
	{
		List<int> pows = new List<int>();
		int currPow = 1;

		n = n % 40;
		bool[] dp = new bool[n+1];
		for (int i = 1; i <= n; i++)
		{
			if (i == currPow)
			{
				pows.Add(currPow);
				dp[i] = true;
				currPow *= 4;
			}
			else
			{
				bool win = false;
				foreach (int pow in pows)
				{
					if (dp[i - pow] == false)
						win = true;
				}
				dp[i] = win;
			}
		}

		Console.WriteLine(string.Join("", from d in dp select d ? "1" : "0"));
		return dp[n] ? "Taro" : "Hanako";
	}
}

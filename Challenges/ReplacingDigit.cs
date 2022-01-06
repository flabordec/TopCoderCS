using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReplacingDigit
{
	public int getMaximumStockWorth(int[] A, int[] D)
	{
		Stack<int> digitsToUse = new Stack<int>();
		for (int i = 0; i < D.Length; i++)
		{
			for (int j = 0; j < D[i]; j++)
				digitsToUse.Push(i + 1);
		}
		Console.WriteLine("Digits to use {0}", string.Join(",", digitsToUse));

		List<List<int>> digitCounts = new List<List<int>>();
		for (int i = 0; i < 7; i++)
			digitCounts.Add(new List<int>());
		foreach (int a in A)
		{
			List<int> cDigits = Digits(a);
			for (int i = 0; i < cDigits.Count; i++)
			{
				digitCounts[i].Add(cDigits[i]);
			}

		}

		int sum = 0;
		int pow = 10000000;
		for (int i = digitCounts.Count - 1; i >= 0; i--)
		{
			pow /= 10;
			if (!digitCounts[i].Any())
				continue;

			digitCounts[i].Sort();
			Console.WriteLine("------------------------------");
			Console.WriteLine("position {0}, digits {1}", i, string.Join(",", digitCounts[i]));
			Console.WriteLine("Digits to use {0}", string.Join(",", digitsToUse));
			for (int j = 0; j < digitCounts[i].Count; j++)
			{
				if (digitsToUse.Any() && digitCounts[i][j] < digitsToUse.Peek())
				{
					digitCounts[i][j] = digitsToUse.Pop();
				}
				sum += digitCounts[i][j] * pow;
			}
			Console.WriteLine("position {0}, digits {1}", i, string.Join(",", digitCounts[i]));
			Console.WriteLine("Digits to use {0}", string.Join(",", digitsToUse));
			Console.WriteLine("Current sum {0}", sum);
		}

		return sum;
	}

	public List<int> Digits(int n)
	{
		List<int> digits = new List<int>();
		while (n > 0)
		{
			digits.Add(n % 10);
			n /= 10;
		}
		return digits;
	}
}
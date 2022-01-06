using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FoxAndSouvenirTheNext
{
	int[, ,] Cache = new int[50, 25, 1300];
	const int NotInitialized = 0;
	const int True = 1;
	const int False = 2;

	int ExpectedSum = 0;
	int NElements = 0;
	int[] Values;

	public string ableToSplit(int[] value)
	{
		this.Values = value;

		int sum = value.Sum();
		if ((sum & 1) != 0)
			return "Impossible";

		int nElements = value.Length;
		if ((nElements & 1) != 0)
			return "Impossible";

		sum /= 2;
		nElements /= 2;
		this.ExpectedSum = sum;
		this.NElements = nElements;

		// Console.WriteLine();
		bool result = Split(0, nElements, 0);
		if (result)
			return "Possible";
		else
			return "Impossible";
	}

	public bool Split(int startIx, int remaining, int sum)
	{
		if (Cache[startIx, remaining, sum] != NotInitialized)
		{
			return Cache[startIx, remaining, sum] == True;
		}
		else if (remaining == 0)
		{
			if (sum == this.ExpectedSum)
			{
				Cache[startIx, remaining, sum] = True;
				return true;
			}
			else
			{
				Cache[startIx, remaining, sum] = False;
				return false;
			}
		}
		else if (sum >= this.ExpectedSum)
		{
			return false;
		}
		else
		{
			for (int i = startIx; i < this.Values.Length; i++)
			{
				bool result = Split(i + 1, remaining - 1, sum + this.Values[i]);
				if (result)
					return true;
			}
			return false;
		}
	}
}

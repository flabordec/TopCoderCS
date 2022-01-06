using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExploringNumbers
{
	public int numberOfSteps(int n)
	{
		int nPrimes = 1000000;
		bool[] primes = new bool[nPrimes];
		for (int i = 1; i < primes.Length; i++)
			primes[i] = true;

		for (int i = 2; i <= Math.Sqrt(primes.Length); i++)
		{
			if (primes[i])
			{
				for (int j = i * i; j < primes.Length; j += i)
					primes[j] = false;
			}
		}

		int origN = n;
		int curr = 1;
		for (; curr <= origN; curr++)
		{
			if (n == 1)
				return -1;

			if (n < nPrimes)
			{
				if (primes[n])
					return curr;
			}
			else
			{
				if (IsPrime(n))
					return curr;
			}

			int sum = 0;
			foreach (int digit in Digits(n))
				sum += digit * digit;
			n = sum;
			
			Console.WriteLine(n);
		}

		return -1;
	}

	private bool IsPrime(int origN)
	{
		for (int i = 2; i <= origN / 2; i++)
		{
			if (origN % i == 0)
				return false;
		}

		return true;
	}

	public IEnumerable<int> Digits(int n)
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


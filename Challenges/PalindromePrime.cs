using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PalindromePrime
{
	bool[] primes;

	public int count(int L, int R)
	{
		primes = new bool[R + 1];
		primes[0] = false;
		primes[1] = false;
		for (int i = 2; i < primes.Length; i++)
			primes[i] = true;


		for (int i = 2; i <= R; i++)
		{
			if (primes[i])
			{
				for (int j = i + i; j <= R; j += i)
					primes[j] = false;
			}
		}

		int count = 0;
		for (int i = L; i <= R; i++)
		{
			if (primes[i] && IsPalindrome(i))
			{
				Console.WriteLine(i);
				count++;
			}
		}
		return count;
	}

	private bool IsPalindrome(int n)
	{
		string s = n.ToString();
		int i = 0; 
		int j = s.Length - 1;
		while (i < j)
		{
			if (s[i] != s[j])
				return false;
			i++;
			j--;
		}
		return true;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dubs
{
	public long count(long L, long R)
	{
		long r = dubsInRangeFast(R);
		long l = dubsInRangeFast(L - 1);
		return r - l;
	}

	private static long dubsInRangeFast(long n)
	{
		if (n <= 10)
			return 0;

		long r = n / 10;
		long ur = n % 10;
		long dr = (n / 10) % 10;

		if (dr > ur)
			r--;
		return r;
	}

	private long dubsInRange(long n)
	{
		if (n <= 10)
		{
			return 0;
		}
		else if (n < 100)
		{
			long dubs = 0;
			for (long i = 11; i <= (n % 100); i += 11)
				dubs++;

			return dubs;
		}
		else
		{
			long powerOfTen = 1;
			long copy = n / 100;
			while (copy > 0)
			{
				powerOfTen *= 10;
				copy /= 10;
			}

			return powerOfTen + dubsInRange(n - (powerOfTen * 10));
		}
	}
}

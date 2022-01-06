using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OmegaUp_ExtravagantVersion
{
	static void Main(string[] args)
	{
		int n = int.Parse(Console.ReadLine());
		for (int i = 0; i < n; i++)
		{
			string line = Console.ReadLine();
			Console.WriteLine(Thousands(line, 0));
		}
	}

	static int Thousands(string s, int ix)
	{
		if (ix == s.Length)
			return 0;
		else if (s[ix] == 'M')
		{
			int accum = 0;
			while (ix < s.Length && s[ix] == 'M')
			{
				accum += 1000;
				ix++;
			}
			return accum + Hundreds(s, ix);
		}
		else
			return Hundreds(s, ix);
	}

	static int Hundreds(string s, int ix)
	{
		if (ix == s.Length)
		{
			return 0;
		}
		else if (
			ix + 1 < s.Length &&
			s[ix] == 'C' &&
			s[ix + 1] == 'D')
		{
			return 400 + Tens(s, ix + 2);
		}
		else if (
			ix + 1 < s.Length &&
			s[ix] == 'C' &&
			s[ix + 1] == 'M')
		{
			return 900 + Tens(s, ix + 2);
		}
		else if (s[ix] == 'C')
		{
			int accum = 0;
			while (ix < s.Length && s[ix] == 'C')
			{
				accum += 100;
				ix++;
			}
			return accum + Tens(s, ix);
		}
		else if (s[ix] == 'D')
		{
			int accum = 500;
			ix++;
			while (ix < s.Length && s[ix] == 'C')
			{
				accum += 100;
				ix++;
			}
			return accum + Tens(s, ix);
		}
		else
		{
			return Tens(s, ix);
		}
	}

	static int Tens(string s, int ix)
	{
		if (ix == s.Length)
		{
			return 0;
		}
		else if (
			ix + 1 < s.Length &&
			s[ix] == 'X' &&
			s[ix + 1] == 'L')
		{
			return 40 + Tens(s, ix + 2);
		}
		else if (
			ix + 1 < s.Length &&
			s[ix] == 'X' &&
			s[ix + 1] == 'C')
		{
			return 90 + Tens(s, ix + 2);
		}
		else if (s[ix] == 'X')
		{
			int accum = 0;
			while (ix < s.Length && s[ix] == 'X')
			{
				accum += 10;
				ix++;
			}
			return accum + Tens(s, ix);
		}
		else if (s[ix] == 'L')
		{
			int accum = 50;
			ix++;
			while (ix < s.Length && s[ix] == 'C')
			{
				accum += 10;
				ix++;
			}
			return accum + Tens(s, ix);
		}
		else
		{
			return Units(s, ix);
		}
	}

	static int Units(string s, int ix)
	{
		if (ix == s.Length)
		{
			return 0;
		}
		else if (
			ix + 1 < s.Length &&
			s[ix] == 'I' &&
			s[ix + 1] == 'V')
		{
			return 4;
		}
		else if (
			ix + 1 < s.Length &&
			s[ix] == 'I' &&
			s[ix + 1] == 'X')
		{
			return 9;
		}
		else if (s[ix] == 'I')
		{
			int accum = 0;
			while (ix < s.Length && s[ix] == 'I')
			{
				accum += 1;
				ix++;
			}
			return accum + Tens(s, ix);
		}
		else if (s[ix] == 'V')
		{
			int accum = 5;
			ix++;
			while (ix < s.Length && s[ix] == 'I')
			{
				accum += 1;
				ix++;
			}
			return accum + Tens(s, ix);
		}
		else
		{
			return Units(s, ix);
		}
	}
}
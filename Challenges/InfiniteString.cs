using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InfiniteString
{
	public string equal1(string s, string t)
	{
		StringBuilder sb = new StringBuilder(s);
		StringBuilder tb = new StringBuilder(t);

		int gcd = GreatestCommonDivisor(sb.Length, tb.Length);
		int lcm = sb.Length * tb.Length / gcd;

		while (sb.Length < lcm)
			sb.Append(s);
		while (tb.Length < lcm)
			tb.Append(t);

		return sb.ToString().Equals(tb.ToString()) ? "Equal" : "Not equal";
	}

	public string equal2(string s, string t)
	{
		StringBuilder sb = new StringBuilder(s);
		StringBuilder tb = new StringBuilder(t);

		while (sb.Length != tb.Length)
		{
			while (sb.Length < tb.Length)
				sb.Append(s);
			while (tb.Length < sb.Length)
				tb.Append(t);
		}

		return sb.ToString().Equals(tb.ToString()) ? "Equal" : "Not equal";
	}

	public int GreatestCommonDivisor(int u, int v)
	{
		// simple cases (termination)
		if (u == v)
			return u;

		if (u == 0)
			return v;

		if (v == 0)
			return u;

		// look for factors of 2
		if ((~u & 1) != 0) // u is even
		{
			if ((v & 1) != 0) // v is odd
				return GreatestCommonDivisor(u >> 1, v);
			else // both u and v are even
				return GreatestCommonDivisor(u >> 1, v >> 1) << 1;
		}

		if ((~v & 1) != 0) // u is odd, v is even
			return GreatestCommonDivisor(u, v >> 1);

		// reduce larger argument
		if (u > v)
			return GreatestCommonDivisor((u - v) >> 1, v);

		return GreatestCommonDivisor((v - u) >> 1, u);

	}
}

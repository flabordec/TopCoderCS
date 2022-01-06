using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ropestring
{
	public string makerope1(string s)
	{
		List<int> ropes = new List<int>();
		int dots = 0;
		int ropeLength = 0;
		for (int i = 0; i < s.Length; i++)
		{
			if (s[i] == '.')
			{
				dots++;
				if (ropeLength > 0)
				{
					ropes.Add(ropeLength);
					ropeLength = 0;
				}
			}
			else if (s[i] == '-')
			{
				ropeLength++;
			}
		}
		if (ropeLength > 0)
			ropes.Add(ropeLength);
		
		var comparison = new Comparison<int>((a, b) =>
		{
			bool evenA = ((a & 1) == 0);
			bool evenB = ((b & 1) == 0);

			if (evenA == evenB)
				return b.CompareTo(a);
			else if (evenA)
				return -1;
			else if (evenB)
				return 1;
			else
				return 0;
		});
		ropes.Sort(comparison);

		int dotsCount = dots - ropes.Count + 1;
		if (dotsCount < 0)
			dotsCount = 0;

		string rope = string.Join(".",
			from r in ropes
			select new string('-', r));
		string dotsEnd = new string('.', dotsCount);
		return rope + dotsEnd;
	}

	public string makerope2(string s)
	{
		List<int> evenRopes = new List<int>();
		List<int> oddRopes = new List<int>();
		int ropeLength = 0;
		for (int i = 0; i < s.Length; i++)
		{
			if (s[i] == '.' && ropeLength > 0)
			{
				if ((ropeLength & 1) == 0)
					evenRopes.Add(ropeLength);
				else
					oddRopes.Add(ropeLength);

				ropeLength = 0;
			}
			else if (s[i] == '-')
			{
				ropeLength++;
			}
		}
		if (ropeLength > 0)
		{
			if ((ropeLength & 1) == 0)
				evenRopes.Add(ropeLength);
			else
				oddRopes.Add(ropeLength);
		}
		var comparison = new Comparison<int>((a, b) => b.CompareTo(a));
		evenRopes.Sort(comparison);
		oddRopes.Sort(comparison);

		StringBuilder builder = new StringBuilder();
		foreach (int evenRope in evenRopes)
		{
			builder.Append(new string('-', evenRope));
			if (builder.Length < s.Length)
				builder.Append(".");
		}

		foreach (int oddRope in oddRopes)
		{
			builder.Append(new string('-', oddRope));
			if (builder.Length < s.Length)
				builder.Append(".");
		}

		while (builder.Length < s.Length)
			builder.Append(".");

		return builder.ToString();
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EllysNumberGuessing
{
	private bool InRange(int i)
	{
		return (i > 0 && i <= 1000000000);
	}

	public int getNumber(int[] guesses, int[] answers)
	{
		var possible = new HashSet<int>();

		int max = guesses[0] + answers[0];
		int min = guesses[0] - answers[0];

		
		if (InRange(max))
			possible.Add(max);
		if (InRange(min))
			possible.Add(min);
		if (!InRange(max) && !InRange(min))
			return -2;

		for (int i = 1; i < guesses.Length; i++)
		{
			max = guesses[i] + answers[i];
			min = guesses[i] - answers[i];

			if (!InRange(max) && !InRange(min))
				return -2;

			possible.IntersectWith(new int[] { max, min });

			if (possible.Count == 0)
				return -2;
		}
		if (possible.Count == 1)
			return possible.First();
		else
			return -1;
	}
}


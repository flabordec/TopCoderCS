using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SortishDiv2
{
	private bool[] RemainingNumbers { get; set; }
	private int[] Sequence { get; set; }
	private int Sortedness { get; set; }

	private int waysInner(int ix)
	{
		while (ix < this.Sequence.Length && this.Sequence[ix] != 0)
		{
			ix++;
		}

		if (ix == this.Sequence.Length)
		{
			int sortedness = 0;
			for (int i = this.Sequence.Length - 1; i >= 0; i--)
			{
				for (int j = i - 1; j >= 0; j--)
				{
					if (this.Sequence[i] > this.Sequence[j])
						sortedness++;
				}
			}
			if (sortedness == this.Sortedness)
				return 1;
			else
				return 0;
		}
		else
		{
			int ways = 0;
			for (int i = 0; i < this.RemainingNumbers.Length; i++)
			{
				if (this.RemainingNumbers[i])
				{
					this.RemainingNumbers[i] = false;
					this.Sequence[ix] = (i + 1);
					ways += waysInner(ix + 1);
					this.Sequence[ix] = 0;
					this.RemainingNumbers[i] = true;
				}
			}

			return ways;
		}
	}

	public int ways(int sortedness, int[] seq)
	{
		this.Sequence = seq;
		this.RemainingNumbers = new bool[seq.Length];
		this.Sortedness = sortedness;
		
		for (int i = 0; i < RemainingNumbers.Length; i++)
			RemainingNumbers[i] = true;
		foreach (int i in seq)
		{
			if (i > 0) 
				RemainingNumbers[i - 1] = false;
		}

		return waysInner(0);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UnionOfIntervals
{
	public int nthElement(int[] lowerBound, int[] upperBound, int n)
	{
		Dictionary<long, int> increments = new Dictionary<long, int>();
		for (int i = 0; i < lowerBound.Length; i++)
		{
			AddKey(increments, lowerBound[i]);
			increments[lowerBound[i]]++;
			AddKey(increments, upperBound[i]+1);
			increments[upperBound[i]+1]--;
		}

		List<long> intervalKeys = (
			from interval in increments.Keys
			orderby interval
			select interval
			).ToList();

		if (n == 0)
			return (int)intervalKeys.First();

		intervalKeys.Insert(0, intervalKeys.First() - 1);

		Console.WriteLine();
		long count = 0;
		long increment = 0;
		for (int i = 1; i < intervalKeys.Count; i++)
		{
			Console.WriteLine(i);
			long curr = intervalKeys[i];
			long prev = intervalKeys[i - 1];

			long intervalLength = curr - prev;

			Console.WriteLine(
				"Count: {0} + ({1}len * {2}inc) = {3}", 
				count, 
				intervalLength, 
				increment,
				count + (intervalLength * increment));
			Console.WriteLine("    (values {0}-{1} modifying increment by {2})", prev, curr - 1, increments[curr]);

			if (count + (intervalLength * increment) > n)
			{
				long needed = n - count;
				long nSteps = needed;
				if (increment != 0)
					nSteps /= increment;
				
				Console.WriteLine("need {0}, distance from bound: {1}", needed, nSteps);
				return (int)(prev + nSteps);
			}

			count += (intervalLength * increment);
			increment += increments[curr];
		}
		// TODO: last number
		return 0;
	}

	private static void AddKey(Dictionary<long, int> increments, long i)
	{
		if (!increments.ContainsKey(i))
			increments.Add(i, 0);
	}
}

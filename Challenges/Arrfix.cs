using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Arrfix
{
	public int mindiff(int[] A, int[] B, int[] F)
	{
		bool[] seen = new bool[A.Length];
		Dictionary<int, int> values = new Dictionary<int, int>();
		foreach (int f in F) 
		{
			if (!values.ContainsKey(f))
				values.Add(f, 0);
			values[f]++;
		}

		foreach (var value in values)
			Console.WriteLine("{0} => {1}", value.Key, value.Value);

		int l = A.Length;
		for (int i = 0; i < l; i++)
		{
			if (A[i] != B[i])
			{
				if (values.ContainsKey(B[i]) && values[B[i]] > 0)
				{
					Console.WriteLine("Fixing a, b: {0}, {1}", A[i], B[i]);
					values[B[i]]--;
					seen[i] = true;

					A[i] = B[i];
				}
			}
		}

		for (int i = 0; i < l; i++)
		{
			if (!seen[i] && values.ContainsKey(B[i]) && values[B[i]] > 0)
			{
				Console.WriteLine("Wasting a, b: {0}, {1}", A[i], B[i]);
				values[B[i]]--;
				seen[i] = true;

				A[i] = B[i];
			}
		}

		int valuesLeft = values.Sum(pair => pair.Value);
		Console.WriteLine("A: {0}", string.Join(",", A));
		Console.WriteLine("B: {0}", string.Join(",", B));
		Console.WriteLine("After fixing values left: {0}", valuesLeft);

		int diffs = 0;
		for (int i = 0; i < l; i++)
		{
			if (!seen[i] && A[i] != B[i])
			{
				valuesLeft--;
				diffs++;
			}
		}

		Console.WriteLine("After wasting values left: {0}", valuesLeft);
		Console.WriteLine("After wasting diffs: {0}", diffs);

		if (valuesLeft > 0)
			diffs += valuesLeft;

		return diffs;
	}
}


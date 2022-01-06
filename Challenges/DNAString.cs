using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DNAString
{
	public int minChanges(int maxPeriod, string[] dna)
	{
		int minResult = int.MaxValue;
		string allDna = string.Join("", dna);
		for (int period = 1; period <= maxPeriod; period++)
		{
			var charactersPerPeriod = new Dictionary<int, int[]>();
			for (int i = 0; i < allDna.Length; i++)
			{
				char c = allDna[i];
				int p = i % period;

				int ci = -1;
				switch (c)
				{
					case 'A':
						ci = 0;
						break;
					case 'C':
						ci = 1;
						break;
					case 'G':
						ci = 2;
						break;
					case 'T':
						ci = 3;
						break;
				}

				if (!charactersPerPeriod.ContainsKey(p))
					charactersPerPeriod.Add(p, new int[4]);

				charactersPerPeriod[p][ci]++;
			}

			//Console.WriteLine("Period: {0}", period);
			//foreach (int p in charactersPerPeriod.Keys)
			//{
			//	Console.WriteLine("{0}", p);
			//	for (int ci = 0; ci < charactersPerPeriod[p].Length; ci++)
			//		Console.WriteLine("    {0} => {1}", ci, charactersPerPeriod[p][ci]);
			//}

			int changes = 0;
			foreach (int p in charactersPerPeriod.Keys)
			{
				int[] values = charactersPerPeriod[p];
				Array.Sort(values);

				for (int i = 0; i < values.Length - 1; i++)
					changes += values[i];
			}
			//Console.WriteLine("Changes: {0}", changes);
			//Console.WriteLine();
			//Console.WriteLine();

			if (changes == 0)
				return 0;

			minResult = Math.Min(changes, minResult);
		}

		return minResult;
	}

	public int minChangesMagus(int maxPeriod, string[] dna)
	{
		int[][] charactersPerPeriod = new int[maxPeriod][];
		for (int i = 0; i < maxPeriod; i++)
			charactersPerPeriod[i] = new int[4];

		int minResult = int.MaxValue;
		string allDna = string.Join("", dna);
		for (int period = 1; period <= maxPeriod; period++)
		{
			for (int i = 0; i < allDna.Length; i++)
			{
				char c = allDna[i];
				int p = i % period;

				int ci = -1;
				switch (c)
				{
					case 'A':
						ci = 0;
						break;
					case 'C':
						ci = 1;
						break;
					case 'G':
						ci = 2;
						break;
					case 'T':
						ci = 3;
						break;
				}

				charactersPerPeriod[p][ci]++;
			}

			int changes = 0;
			for (int p = 0; p < period; p++)
			{
				int[] values = charactersPerPeriod[p];
				changes = values.Sum() - values.Max();
			}

			if (changes == 0)
				return 0;

			minResult = Math.Min(changes, minResult);

			for (int p = 0; p < period; p++)
				for (int i = 0; i < charactersPerPeriod[p].Length; i++)
					charactersPerPeriod[p][i] = 0;
		}

		return minResult;
	}

	public int minChangesOscar(int maxPeriod, string[] dna)
	{
		int changes = 100000000;
		string conc = string.Join(string.Empty, dna);
		for (int i = maxPeriod; i >= 1; i--)
		{
			int counter = 0;
			List<Dictionary<char, int>> columns = new List<Dictionary<char, int>>();
			for (int w = 0; w < i; w++)
				columns.Add(new Dictionary<char, int>());
			for (int j = 0; j < conc.Length; j++)
			{
				if (columns[counter].ContainsKey(conc[j]))
					columns[counter][conc[j]]++;
				else
					columns[counter].Add(conc[j], 1);
				counter++;
				if (counter == i)
					counter = 0;
			}
			int sum = 0;
			foreach (Dictionary<char, int> column in columns)
			{
				sum += column.Sum(x => x.Value) - column.Values.Max();
			}
			if (sum < changes)
				changes = sum;
		}
		return changes;
	}
}

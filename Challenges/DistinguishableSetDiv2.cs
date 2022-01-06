using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DistinguishableSetDiv2
{
	public int count(string[] answer)
	{
		int M = 1;
		for (int i = 0; i < answer.First().Length; i++)
			M *= 2;

		int count = 0;
		for (int bitSet = 0; bitSet < M; bitSet++)
		{
			Console.WriteLine("Bit set: {0}", Convert.ToString(bitSet, 2));

			HashSet<string> answers = new HashSet<string>();
			bool allUnique = true;
			foreach (string a in answer)
			{
				string currentAnswer = BuildAnswer(bitSet, a);
				Console.WriteLine("Next answer: {0}", currentAnswer);
				if (answers.Contains(currentAnswer))
				{
					allUnique = false;
					break;
				}
				answers.Add(currentAnswer);
			}
			if (allUnique)
				count++;
			Console.WriteLine("Count: {0}", count);
		}
		return count;
	}

	public string BuildAnswer(int bitSet, string answer)
	{
		StringBuilder builder = new StringBuilder();
		for (int i = 0; i < answer.Length; i++)
		{
			if (IsBitSet(bitSet, i))
				builder.Append(answer[i]);
		}
		return builder.ToString();
	}

	public bool IsBitSet(int i, int bit)
	{
		return (i & (1 << bit)) != 0;
	}
}

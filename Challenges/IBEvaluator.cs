using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IBEvaluator
{
	public int[] getSummary(int[] predictedGrades, int[] actualGrades)
	{
		int total = predictedGrades.Length;
		int[] differences = new int[7];
		for (int i = 0; i < total; i++)
		{
			int difference = Math.Abs(predictedGrades[i] - actualGrades[i]);
			differences[difference]++;
		}

		for (int i = 0; i < differences.Length; i++)
		{
			differences[i] = differences[i] * 100 / total;
		}
		Console.WriteLine(string.Join(", ", differences));
		return differences;
	}
}

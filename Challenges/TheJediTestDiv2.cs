using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TheJediTestDiv2
{
	public int countSupervisors(int[] students, int Y, int J)
	{
		int minJedis = int.MaxValue;
		for (int i = 0; i < students.Length; i++)
		{
			int currJedis = 0;
			int left = students[i] - Y;
			if (left > 0)
			{
				currJedis += (int)Math.Ceiling((double)left / J);
			}
			for (int j = 0; j < students.Length; j++)
			{
				if (j == i)
					continue;
				currJedis += (int)Math.Ceiling((double)students[j] / J);
			}
			minJedis = Math.Min(currJedis, minJedis);
		}
		return minJedis;
	}

}

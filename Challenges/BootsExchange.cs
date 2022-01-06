using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BootsExchange
{
	public int leastAmount(int[] left, int[] right)
	{
		int[] quantities = new int[1001];

		for (int i = 0; i < left.Length; i++)
		{
			quantities[left[i]]++;
			quantities[right[i]]--;
		}

		int sum = 0;
		for (int i = 0; i < quantities.Length; i++)
		{
			if (quantities[i] > 0)
				sum += quantities[i];
		}
		return sum;
	}
}
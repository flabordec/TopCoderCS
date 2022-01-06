using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ModularInequality
{
	long MinValue = -1000000000L * 50;
	long MaxValue = 1000000000L * 50;

	public int countSolutions(int[] A, int P)
	{
		long left = MinValue;
		long right = MaxValue;

		while (left < right)
		{
			long center = Average(left, right);

			long prev = CalculateSum(A, center - 1);
			long current = CalculateSum(A, center);
			long next = CalculateSum(A, center + 1);

			if (prev >= current)
				left = center;
			if (next >= current)
				right = center;
		}
		Console.WriteLine(left);
		long centerIx = left;
		long centerValue = CalculateSum(A, centerIx);
		if (centerValue > P)
			return 0;

		long leftIx = BinarySearchLeft(A, P, MinValue, centerIx);
		long rightIx = BinarySearchRight(A, P, centerIx, MaxValue);

		return (int)(rightIx - leftIx + 1);
	}

	private long BinarySearchLeft(int[] A, int P, long leftS, long rightS)
	{
		long low = leftS;
		long high = rightS;
		while (low <= high)
		{
			long mid = Average(low, high);
			long prev = CalculateSum(A, mid - 1);
			long current = CalculateSum(A, mid);

			if (!(prev <= P) && current <= P)
			{
				Console.WriteLine("Returning {0} ({1}, {2})", mid, low, high);
				return mid;
			}

			if (current <= P)
				high = mid - 1;
			else
				low = mid + 1;
		}
		return rightS;
	}

	private long BinarySearchRight(int[] A, int P, long leftS, long rightS)
	{
		long low = leftS;
		long high = rightS;
		while (low <= high)
		{
			long mid = Average(low, high);
			long current = CalculateSum(A, mid);
			long next = CalculateSum(A, mid + 1);

			if (!(next <= P) && current <= P)
			{
				Console.WriteLine("Returning {0} ({1}, {2})", mid, low, high);
				return mid;
			}

			if (current <= P)
				low = mid + 1;
			else
				high = mid - 1;
		}
		return leftS;
	}

	private long Average(long left, long right)
	{
		return (right + left) >> 1;
	}

	private long CalculateSum(int[] A, long offset)
	{
		long sum = 0;
		foreach (int a in A)
			sum += Math.Abs(a - offset);
		return sum;
	}
}


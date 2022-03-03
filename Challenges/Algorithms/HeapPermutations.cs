using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Algorithms
{
	public static class HeapPermutations
	{
		public static IEnumerable<T[]> EnumeratePermutations<T>(T[] elements)
		{
			return EnumeratePermutations(elements.Length - 1, elements);
		}

		private static IEnumerable<T[]> EnumeratePermutations<T>(int n, T[] elements)
		{
			if (n == 0)
			{
				yield return elements;
			}
			else
			{
				for (int c = 0; c <= n; c++)
				{
					foreach (T[] permutation in EnumeratePermutations(n - 1, elements))
						yield return permutation;
					Swap(elements, n, c);
				}
			}
		}

		public static IEnumerable<T[]> Permutations<T>(T[] elements)
		{
			var results = new List<T[]>();
			Permutations(elements.Length - 1, elements, results);
			return results;
		}

		private static void Permutations<T>(int n, T[] elements, List<T[]> results)
		{
			if (n == 0)
			{
				// Need to create a copy because if not all the arrays are the same reference
				T[] copy = new T[elements.Length];
				Array.Copy(elements, copy, elements.Length);
				results.Add(copy);
			}
			else
			{
				for (int c = 0; c <= n; c++)
				{
					Permutations(n - 1, elements, results);
					Swap(elements, n, c);
				}
			}
		}

		private static void Swap<T>(T[] str, int i, int j)
		{
			T temp = str[j];
			str[j] = str[i];
			str[i] = temp;
		}
	}
}

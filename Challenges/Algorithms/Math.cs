using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.Algorithms
{
	class MathHelpers
	{
		/// <summary>
		/// Returns the smallest positive integer that is divisible by both <paramref name="u"/> 
		/// and <paramref name="v"/>. For 8 and 12 the LCM is 24.
		/// </summary>
		/// <param name="u">The first number</param>
		/// <param name="v">The second number</param>
		/// <returns>The least common multiple</returns>
		public static int LeastCommonMultiple(int u, int v)
		{
			int gcd = MathHelpers.GreatestCommonDivisor(u, v);
			return (u * v) / gcd;
		}

		/// <summary>
		/// Returns the largest positive integer that divides <paramref name="u"/> and 
		/// <paramref name="v"/> without a remainder. For 8 and 12 the GCD is 4.
		/// </summary>
		/// <param name="u">The first number</param>
		/// <param name="v">The second number</param>
		/// <returns>The greatest common divisor</returns>
		public static int GreatestCommonDivisor(int u, int v)
		{
			// simple cases (termination)
			if (u == v)
				return u;

			if (u == 0)
				return v;

			if (v == 0)
				return u;

			// look for factors of 2
			if ((~u & 1) != 0) // u is even
			{
				if ((v & 1) != 0) // v is odd
					return GreatestCommonDivisor(u >> 1, v);
				else // both u and v are even
					return GreatestCommonDivisor(u >> 1, v >> 1) << 1;
			}

			if ((~v & 1) != 0) // u is odd, v is even
				return GreatestCommonDivisor(u, v >> 1);

			// reduce larger argument
			if (u > v)
				return GreatestCommonDivisor((u - v) >> 1, v);

			return GreatestCommonDivisor((v - u) >> 1, u);

		}
	}
}

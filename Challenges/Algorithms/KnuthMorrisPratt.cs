using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Algorithms
{
	class KnuthMorrisPratt
	{
		/// <summary>
		/// Returns the position in which <paramref name="word"/> is found inside 
		/// <paramref name="sequence"/>.
		/// </summary>
		/// <param name="word">The word to search</param>
		/// <param name="sequence">The sequence to search</param>
		/// <returns>
		/// The index where word is found inside sequence or -1 if it is not found.
		/// </returns>
		public int SearchInString(string word, string sequence)
		{
			int m = 0;
			int i = 0;
			int[] table = BuildTable(word);

			while (m + i < sequence.Length)
			{
				if (word[i] == sequence[m + i])
				{
					if (i == word.Length - 1)
						return m;
					i++;
				}
				else
				{
					if (table[i] > -1)
					{
						m = m + i - table[i];
						i = table[i];
					}
					else
					{
						i = 0;
						m++;
					}
				}
			}

			return -1;
		}

		private int[] BuildTable(string word)
		{
			int[] table = new int[word.Length];
			int pos = 2;
			int cnd = 0;

			if (word.Length >= 1)
				table[0] = -1;
			if (word.Length >= 2)
				table[1] = 0;

			while (pos < word.Length)
			{
				if (word[pos - 1] == word[cnd])
				{
					cnd++;
					table[pos] = cnd;
					pos++;
				}
				else if (cnd > 0)
				{
					cnd = table[cnd];
				}
				else
				{
					table[pos] = 0;
					pos++;
				}
			}

			return table;
		}
	}
}

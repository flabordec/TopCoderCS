using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam.Round_1C_2009
{
	public class AllYourBase
	{
		public static string AllYourBaseImpl(string inputFilePath)
		{
			StringBuilder output = new StringBuilder();
			string[] lines = File.ReadAllLines(inputFilePath);
			int numCases = int.Parse(lines[0]);
			for (int caseNumber = 1; caseNumber <= numCases; caseNumber++)
			{
				string line = lines[caseNumber];
				Dictionary<char, int> characterValues = new Dictionary<char, int>();
				
				char[] characters = line.ToCharArray();
				characterValues.Add(characters[0], 1);
				
				int i = 1;
				for (; i < characters.Length; i++)
				{
					if (!characterValues.ContainsKey(characters[i]))
					{
						characterValues.Add(characters[i], 0);
						break;
					}
				}
				int nextValue = 2;
				for (; i < characters.Length; i++)
				{
					if (!characterValues.ContainsKey(characters[i]))
						characterValues.Add(characters[i], nextValue++);
				}

				long b = Math.Max(characterValues.Count, 2);
				long power = 1;
				long total = 0;
				for (i = characters.Length - 1; i >= 0; i--)
				{
					long currentValue = characterValues[characters[i]];
					total += currentValue * power;
					power *= b;
				}
				output.AppendFormat("Case #{0}: {1}\n", caseNumber, total);
			}
			return output.ToString();
		}

	}
}

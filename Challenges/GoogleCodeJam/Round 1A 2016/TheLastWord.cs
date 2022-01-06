using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam.Round_1A_2016
{
	public class TheLastWord
	{
		public static string TheLastWordImpl(string inputFilePath)
		{
			string[] lines = File.ReadAllLines(inputFilePath);

			StringBuilder output = new StringBuilder();
			int t = int.Parse(lines[0]);
			for (int i = 0; i < t; i++)
			{
				string line = lines[i + 1];

				StringBuilder builder = new StringBuilder(line.Length);
				builder.Append(line[0]);
				for (int j = 1; j < line.Length; j++)
				{
					if (line[j] >= builder[0])
						builder.Insert(0, line[j]);
					else
						builder.Append(line[j]);

					//Console.WriteLine("Case #{0}: {1}", i + 1, builder);
				}
				output.AppendFormat("Case #{0}: {1}\n", i + 1, builder);
			}
			return output.ToString();
		}
	}
}

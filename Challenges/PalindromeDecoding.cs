using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PalindromeDecoding
{
	public string decode(string code, int[] position, int[] length)
	{
		StringBuilder builder = new StringBuilder(code);
		
		for (int i = 0; i < position.Length; i++)
		{
			int pos = position[i];
			int len = length[i];

			for (int j = 0; j < len; j++)
			{
				int codePos = pos + j;
				int retPos = pos + len;

				builder.Insert(retPos, builder[codePos]);
			}
		}
		return builder.ToString();
	}
}

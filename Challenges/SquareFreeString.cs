using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SquareFreeString
{
	public string isSquareFree(string s)
	{
		for (int l = 1; l <= s.Length / 2; l++)
		{
			for (int i = 0; i < s.Length - (l * 2) + 1; i++)
			{

				// check the current numbers
				bool allEqual = true;
				for (int j = 0; j < l; j++)
				{
					if (s[i + j] != s[i + +j + l])
					{
						allEqual = false;
						break;
					}
				}
				if (allEqual)
					return "not square-free";
			}
		}
		return "square-free";
	}

	public string isSquareFreeFernando(string s)
	{
		int currentWordLen = 1;
		int sHalfLen = s.Length / 2;
		while (currentWordLen <= sHalfLen)
		{
			for (int i = 0; i < (s.Length - currentWordLen); i++)
			{
				string firstPart = s.Substring(i, currentWordLen);
				string secondPart = s.Substring(i + currentWordLen, currentWordLen);
				if (firstPart.Equals(secondPart))
					return "not square-free";
				if (i + (currentWordLen * 2) == s.Length)
					break;
			}
			currentWordLen++;
		}
		return "square-free";
	}
}

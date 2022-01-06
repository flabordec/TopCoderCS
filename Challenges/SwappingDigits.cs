using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SwappingDigits
{
	public string minNumber(string num)
	{
		char[] numArr = num.ToCharArray();
		string min = num;
		char temp;
		for (int i = 0; i < numArr.Length; i++)
		{
			for (int j = 0; j < numArr.Length; j++)
			{
				temp = numArr[i];
				numArr[i] = numArr[j];
				numArr[j] = temp;
				
				string xStr = new string(numArr);
				if (xStr[0] != '0' && xStr.CompareTo(min) < 0)
					min = xStr;
				
				temp = numArr[i];
				numArr[i] = numArr[j];
				numArr[j] = temp;
			}
		}
		return string.Format("{0}", min);
	}
}


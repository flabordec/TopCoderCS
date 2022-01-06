using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IDNumberVerification
{
	public string verify(string id, string[] regionCodes)
	{
		Console.WriteLine("---------------------------");

		string region = id.Substring(0, 6);
		Console.WriteLine("Region {0}", region);
		if (!regionCodes.Contains(region))
			return "Invalid";

		int year = int.Parse(id.Substring(6, 4));
		int month = int.Parse(id.Substring(10, 2));
		int day = int.Parse(id.Substring(12, 2));

		Console.WriteLine("Birth: {0}-{1}-{2}", year, month, day);

		if (year < 1900 || year > 2011)
			return "Invalid";

		if (month == 0 || month >= 13)
			return "Invalid";

		bool leap = ((year % 4) == 0 && (year % 100) != 0) || (year % 400 == 0);
		int[] monthDays = new [] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
		if (leap)
			monthDays[1]++;

		Console.WriteLine("Month days {0}", monthDays[month - 1]);
		if (day == 0 || day > monthDays[month - 1])
			return "Invalid";

		int expectedChecksum = (id[17] != 'X') ? id[17] - '0' : 10;
		Console.WriteLine("Expected checksum {0}", expectedChecksum);
		int actualChecksum = Checksum(id);
		Console.WriteLine("Actual checksum {0}", actualChecksum);
		if (actualChecksum != expectedChecksum)
			return "Invalid";

		string sequential = id.Substring(14, 3);
		Console.WriteLine("Sequential {0}", sequential);
		int sequentialNum = int.Parse(sequential);
		Console.WriteLine("Sequential {0}", sequentialNum);
		if (sequentialNum == 0)
			return "Invalid";
		else if ((sequentialNum % 2) == 0)
			return "Female";
		else
			return "Male";
	}

	private int Checksum(string id)
	{
		int sum = 0;
		for (int i = 0; i < 17; i++)
		{
			int x = (id[i] - '0');
			sum += (x * (1 << (17 - i)));
			sum = sum % 11;
		}
		Console.WriteLine("Sum {0}", sum);
		return (12 - sum) % 11;
	}
}
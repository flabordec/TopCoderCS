using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SalaryCalculator
{
	public double calcHours(int P1, int P2, int salary)
	{
		if (P1 * 200 >= salary)
			return (double)salary / P1;
		else
			return 200.0 + ((double)salary - (P1 * 200)) / P2;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WidgetRepairs
{
	public int days(int[] arrivals, int numPerDay)
	{
		int count = 0;
		int workDays = 0;
		for (int i = 0; i < arrivals.Length; i++)
		{
			count += arrivals[i];
			if (count > 0)
			{
				count = Math.Max(0, count - numPerDay);
				workDays++;
			}
		}
		while (count > 0)
		{
			count -= numPerDay;
			workDays++;
		}
		return workDays;
	}
}

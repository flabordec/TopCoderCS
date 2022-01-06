using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CalendarRecycle
{
	public int useAgain(int year)
	{
		DateTime date = new DateTime(year, 1, 1);
		int dayOfWeek = (int)date.DayOfWeek;
		bool isLeap = DateTime.IsLeapYear(year);
		
		int currentDayOfWeek = dayOfWeek;
		bool currentIsLeap = isLeap;

		while (true)
		{
			year++;

			currentIsLeap =
				(year % 4 == 0) &&     //divisible by four, and
				(
					year % 100 != 0 || // not divisible by 100, unless
					year % 400 == 0    // also divisible by 400
				);
			currentDayOfWeek =
				(currentIsLeap ? currentDayOfWeek + 2 : currentDayOfWeek + 1) % 7;

			if (dayOfWeek == currentDayOfWeek && isLeap == currentIsLeap)
				return year;
		}
	}
}

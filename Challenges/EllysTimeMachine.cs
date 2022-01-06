using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class EllysTimeMachine
{
	public string getTime(string time)
	{
		Dictionary<string, string> minutesToHours = new Dictionary<string, string>();
		minutesToHours.Add("00", "12");
		minutesToHours.Add("05", "01");
		minutesToHours.Add("10", "02");
		minutesToHours.Add("15", "03");
		minutesToHours.Add("20", "04");
		minutesToHours.Add("25", "05");
		minutesToHours.Add("30", "06");
		minutesToHours.Add("35", "07");
		minutesToHours.Add("40", "08");
		minutesToHours.Add("45", "09");
		minutesToHours.Add("50", "10");
		minutesToHours.Add("55", "11");

		Dictionary<string, string> hoursToMinutes = new Dictionary<string, string>();
		hoursToMinutes.Add("12", "00");
		hoursToMinutes.Add("01", "05");
		hoursToMinutes.Add("02", "10");
		hoursToMinutes.Add("03", "15");
		hoursToMinutes.Add("04", "20");
		hoursToMinutes.Add("05", "25");
		hoursToMinutes.Add("06", "30");
		hoursToMinutes.Add("07", "35");
		hoursToMinutes.Add("08", "40");
		hoursToMinutes.Add("09", "45");
		hoursToMinutes.Add("10", "50");
		hoursToMinutes.Add("11", "55");
			

		string[] timeSplit = time.Split(':');
		string hours = timeSplit[0];
		string minutes = timeSplit[1];
		return string.Format("{0}:{1}", 
			minutesToHours[minutes],
			hoursToMinutes[hours]);
		
	}
}

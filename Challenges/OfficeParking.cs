using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OfficeParking
{
	public int spacesUsed(string[] events)
	{
		Dictionary<string, int> parkingSpots = new Dictionary<string, int>();
		SortedSet<int> parking = new SortedSet<int>();
		HashSet<int> spotsUsed = new HashSet<int>();

		for (int i = 0; i < 50; i++)
			parking.Add(i);

		foreach (string evt in events)
		{
			string[] evtSplit = evt.Split(' ');
			string name = evtSplit[0];
			string action = evtSplit[1];

			if (action == "arrives")
			{
				int nextParkingSpot = parking.First();
				parking.Remove(nextParkingSpot);
				parkingSpots.Add(name, nextParkingSpot);
				spotsUsed.Add(nextParkingSpot);
			}
			else if (action == "departs")
			{
				int parkingSpot = parkingSpots[name];
				parkingSpots.Remove(name);
				parking.Add(parkingSpot);
			}
		}

		return spotsUsed.Count;
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution_HackerlandRadioTransmitters
{
	static void Main(String[] args)
	{
		string[] tokens_n = Console.ReadLine().Split(' ');
		int k = Convert.ToInt32(tokens_n[1]);

		string[] houses_temp = Console.ReadLine().Split(' ');
		int[] houses = Array.ConvertAll(houses_temp, int.Parse);
		Array.Sort(houses);

		int transmitters = 0;
		int i = 0;
		while (i < houses.Length)
		{
			int currentHouse = houses[i];

			while (i < houses.Length - 1 &&
				houses[i + 1] - currentHouse <= k)
			{
				Console.Error.WriteLine(
					$"Skipping house {houses[i]} because {houses[i + 1]} can reach it");
				i++;
			}

			// if the next house can't handle it, then install a transmitter here
			Console.Error.WriteLine($"Setting transmitter in {houses[i]}");
			int maxReach = houses[i] + k;
			transmitters++;

			// advance the house pointer to the next house that is still within range of the 
			// current transmitter. 
			while (
				i < houses.Length &&
				houses[i] <= maxReach)
			{
				Console.Error.WriteLine(
					$"Skipping house {houses[i]} the transmitter we just set can reach it");

				i++;
			}

		}

		Console.WriteLine(transmitters);
	}
}

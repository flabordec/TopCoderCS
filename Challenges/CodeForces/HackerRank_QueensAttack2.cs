using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution_QueensAttack2
{
	static void Main(string[] args)
	{
		string[] tokens_n = Console.ReadLine().Split(' ');
		int n = Convert.ToInt32(tokens_n[0]);
		int k = Convert.ToInt32(tokens_n[1]);

		int nearestLeft = 0;
		int nearestRight = n + 1;
		int nearestTop = 0;
		int nearestBottom = n + 1;

		string[] tokens_rQueen = Console.ReadLine().Split(' ');
		int rQueen = Convert.ToInt32(tokens_rQueen[0]);
		int cQueen = Convert.ToInt32(tokens_rQueen[1]);

		int nearestTopLeft = cQueen - 1 - Math.Min(
			(rQueen - nearestTop - 1), // Moves to top
			(cQueen - nearestLeft - 1) // Moves to left
			);
		int nearestTopRight = 1 + cQueen + Math.Min(
			(rQueen - nearestTop - 1), // Moves to top
			(nearestRight - cQueen - 1) // Moves to right
			);
		int nearestBottomLeft = cQueen - 1 - Math.Min(
			(nearestBottom - rQueen - 1), // Moves to bottom
			(cQueen - nearestLeft - 1) // Moves to left
			);
		int nearestBottomRight = 1 + cQueen + Math.Min(
			(nearestBottom - rQueen - 1), // Moves to bottom
			(nearestRight - cQueen - 1) // Moves to right
		);

		Console.Error.WriteLine(
			$"Top: {nearestTop}, moves {rQueen - nearestTop - 1}\n" +
			$"Bottom: {nearestBottom}, moves {nearestBottom - rQueen - 1}\n" +
			$"Left: {nearestLeft}, moves {cQueen - nearestLeft - 1}\n" +
			$"Right: {nearestRight}, moves {nearestRight - cQueen - 1}\n" +
			$"Top left: {nearestTopLeft}, moves {cQueen - nearestTopLeft - 1}\n" +
			$"Top right: {nearestTopRight}, moves {nearestTopRight - cQueen - 1}\n" +
			$"Bottom left: {nearestBottomLeft}, moves {cQueen - nearestBottomLeft - 1}\n" +
			$"Bottom right: {nearestBottomRight}, moves {nearestBottomRight - cQueen - 1}\n\n"
		);


		for (int obstacleIx = 0; obstacleIx < k; obstacleIx++)
		{
			string[] tokens_rObstacle = Console.ReadLine().Split(' ');
			int rObstacle = Convert.ToInt32(tokens_rObstacle[0]);
			int cObstacle = Convert.ToInt32(tokens_rObstacle[1]);
			// your code goes here
			if (rObstacle == rQueen)
			{
				if (cObstacle < cQueen)
				{
					nearestLeft = Math.Max(cObstacle, nearestLeft);
				}
				else if (cObstacle > cQueen)
				{
					nearestRight = Math.Min(cObstacle, nearestRight);
				}
			}
			else if (cObstacle == cQueen)
			{
				if (rObstacle < rQueen)
				{
					nearestTop = Math.Max(rObstacle, nearestTop);
				}
				else if (rObstacle > rQueen)
				{
					nearestBottom = Math.Min(rObstacle, nearestBottom);
				}
			}
			else
			{
				int dColumns = cObstacle - cQueen;
				int dRows = rObstacle - rQueen;

				if (Math.Abs(dColumns) == Math.Abs(dRows))
				{
					if (dColumns > 0 && dRows > 0)
					{
						nearestBottomRight = Math.Min(cObstacle, nearestBottomRight);
					}
					else if (dColumns < 0 && dRows > 0)
					{
						nearestBottomLeft = Math.Max(cObstacle, nearestBottomLeft);
					}
					else if (dColumns > 0 && dRows < 0)
					{
						nearestTopRight = Math.Min(cObstacle, nearestTopRight);
					}
					else if (dColumns < 0 && dRows < 0)
					{
						nearestTopLeft = Math.Max(cObstacle, nearestTopLeft);
						
					}
				}
			}
		}
		Console.Error.WriteLine(
			$"Top: {nearestTop}, moves {rQueen - nearestTop - 1}\n" +
			$"Bottom: {nearestBottom}, moves {nearestBottom - rQueen - 1}\n" +
			$"Left: {nearestLeft}, moves {cQueen - nearestLeft - 1}\n" +
			$"Right: {nearestRight}, moves {nearestRight - cQueen - 1}\n" +
			$"Top left: {nearestTopLeft}, moves {cQueen - nearestTopLeft - 1}\n" +
			$"Top right: {nearestTopRight}, moves {nearestTopRight - cQueen - 1}\n" +
			$"Bottom left: {nearestBottomLeft}, moves {cQueen - nearestBottomLeft - 1}\n" +
			$"Bottom right: {nearestBottomRight}, moves {nearestBottomRight - cQueen - 1}\n"
			);

		Console.WriteLine(
			(cQueen - nearestLeft - 1) +
			(nearestRight - cQueen - 1) +
			(rQueen - nearestTop - 1) +
			(nearestBottom - rQueen - 1) +
			(cQueen - nearestTopLeft - 1) +
			(nearestTopRight - cQueen - 1) +
			(cQueen - nearestBottomLeft - 1) +
			(nearestBottomRight - cQueen - 1)
		);
	}

}

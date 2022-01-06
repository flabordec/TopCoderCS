using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

	public class RobotOnMoonEasy
	{
		public string isSafeCommand(string[] board, string S)
		{
			char[,] nBoard = new char[board.Length, board[0].Length];

			int roboX = -1;
			int roboY = -1;
			for (int y = 0; y < board.Length; y++)
			{
				for (int x = 0; x < board[y].Length; x++)
				{
					if (board[y][x] == 'S')
					{
						roboX = x;
						roboY = y;
						nBoard[y, x] = '.';
					}
					else
					{
						nBoard[y, x] = board[y][x];
					}
				}
			}

			foreach (char c in S)
			{
				int roboNX = roboX;
				int roboNY = roboY;
				switch (c)
				{
					case 'U':
						roboNY--;
						break;
					case 'D':
						roboNY++;
						break;
					case 'L':
						roboNX--;
						break;
					case 'R':
						roboNX++;
						break;
				}

				if (roboNY < 0 || roboNY >= board.Length)
					return "Dead";
				if (roboNX < 0 || roboNX >= board[roboNY].Length)
					return "Dead";

				if (nBoard[roboNY, roboNX] == '.')
				{
					roboX = roboNX;
					roboY = roboNY;
				}
			}

			return "Alive";
		}
	}

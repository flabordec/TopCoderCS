using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class XMarksTheSpot
{
	class Position
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Position(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public override string ToString()
		{
			return string.Format("<{0},{1}>", X, Y);
		}
	}

	public int countArea(string[] board)
	{
		List<Position> positions = new List<Position>();
		Position topLeft = new Position(board[0].Length, board.Length);
		Position bottomRight = new Position(0, 0);
		for (int y = 0; y < board.Length; y++)
		{
			for (int x = 0; x < board[y].Length; x++)
			{
				if (board[y][x] == 'O')
				{
					topLeft.X = Math.Min(topLeft.X, x);
					bottomRight.X = Math.Max(bottomRight.X, x);

					topLeft.Y = Math.Min(topLeft.Y, y);
					bottomRight.Y = Math.Max(bottomRight.Y, y);
				}
				else if (board[y][x] == '?')
					positions.Add(new Position(x, y));
			}
		}

		
		int sum = 0;
		for (int i = 0; i < (1 << positions.Count); i++)
		{
			Position tlCurr = new Position(topLeft.X, topLeft.Y);
			Position brCurr = new Position(bottomRight.X, bottomRight.Y);

			for (int j = 0; j < positions.Count; j++)
			{
				if (BitSet(i, j))
				{
					tlCurr.X = Math.Min(tlCurr.X, positions[j].X);
					brCurr.X = Math.Max(brCurr.X, positions[j].X);

					tlCurr.Y = Math.Min(tlCurr.Y, positions[j].Y);
					brCurr.Y = Math.Max(brCurr.Y, positions[j].Y);
				}
			}
			int cSum = ((brCurr.X - tlCurr.X + 1) * (brCurr.Y - tlCurr.Y + 1));
			//Console.WriteLine("{0} => {1} to {2} => sum {3}", i, tlCurr, brCurr, cSum);
			sum += cSum;
		}
		return sum;
	}

	private bool BitSet(int value, int bitIndex)
	{
		return (value & (1 << bitIndex)) != 0;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.FiveThirtyEight
{
	public class NiceGameOfChess
	{
		public int Rows { get; }
		public int Columns { get; }

		public NiceGameOfChess(int rows, int columns)
		{
			this.Rows = rows;
			this.Columns = columns;
		}

		public long PawnDp(int row, int column, int endColumn)
		{
			long[,] dp = new long[this.Rows, this.Columns];
			dp[row, column] = 1;
			for (int nRow = row + 1; nRow < this.Rows; nRow++)
			{
				for (int nCol = 0; nCol < this.Columns; nCol++)
				{
					if (nCol > 0)
						dp[nRow, nCol] += dp[nRow - 1, nCol - 1];

					dp[nRow, nCol] += dp[nRow - 1, nCol];

					if (nCol < this.Columns - 1)
						dp[nRow, nCol] += dp[nRow - 1, nCol + 1];

					Console.Write("{0,10}", dp[nRow, nCol]);
				}
				Console.WriteLine();
			}

			

			return dp[this.Rows - 1, endColumn];
		}

		public long PawnRecursive(int row, int column, int endColumn) {
			if (column < 0)
				return 0;
			if (column >= this.Columns)
				return 0;

			if (row == this.Rows - 1)
			{
				if (column == endColumn)
					return 1;
				else
					return 0;
			}
			else
			{
				long sum = 0;
				sum += PawnRecursive(row + 1, column - 1, endColumn);
				sum += PawnRecursive(row + 1, column, endColumn);
				sum += PawnRecursive(row + 1, column + 1, endColumn);
				return sum;
			}
		}

		long[,] Memo;

		public long PawnRecursiveMemo(int row, int column, int endColumn)
		{
			Memo = new long[this.Rows, this.Columns];
			for (int i = 0; i < Memo.GetLength(0); i++)
				for (int j = 0; j < Memo.GetLength(1); j++)
					Memo[i, j] = -1;

			return PawnRecursiveMemoInternal(row, column, endColumn);
		}
		private long PawnRecursiveMemoInternal(int row, int column, int endColumn)
		{
			if (column < 0)
				return 0;
			if (column >= this.Columns)
				return 0;

			if (row == this.Rows - 1)
			{
				if (column == endColumn)
					return 1;
				else
					return 0;
			}

			if (Memo[row, column] == -1)
			{
				long sum = 0;
				sum += PawnRecursiveMemoInternal(row + 1, column - 1, endColumn);
				sum += PawnRecursiveMemoInternal(row + 1, column, endColumn);
				sum += PawnRecursiveMemoInternal(row + 1, column + 1, endColumn);
				Memo[row, column] = sum;
			}

			return Memo[row, column];
		}
	}
}

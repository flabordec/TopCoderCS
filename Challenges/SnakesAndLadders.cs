using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    public class Solution
    {
        public int SnakesAndLadders(int[][] board)
        {
            int boardLength = board.Length * board.Length;

            int[,] distances = new int[board.Length, board.Length];
            for (int i = 0; i < distances.GetLength(0); i++)
            {
                for (int j = 0; j < distances.GetLength(1); j++)
                {
                    distances[i, j] = -1;
                }
            }
            distances[distances.GetLength(0) - 1, 0] = 0;

            bool stable = false;
            while (!stable)
            {
                stable = true;
                for (int i = 1; i <= boardLength; i++)
                {
                    (int Row, int Col) prev = GetIndex(board, i);
                    if (distances[prev.Row, prev.Col] == -1)
                        continue;
                    for (int j = 1; j <= 6 && i + j <= boardLength; j++)
                    {
                        (int Row, int Col) curr = GetIndex(board, i + j);
                        if (board[curr.Row][curr.Col] != -1)
                        {
                            curr = GetIndex(board, board[curr.Row][curr.Col]);
                        }
                        if (distances[prev.Row, prev.Col] + 1 < distances[curr.Row, curr.Col] || distances[curr.Row, curr.Col] == -1)
                        {
                            distances[curr.Row, curr.Col] = distances[prev.Row, prev.Col] + 1;
                            stable = false;
                        }
                    }
                }
            }

            (int Row, int Col) goal = GetIndex(board, boardLength);
            return distances[goal.Row, goal.Col];
        }

        public (int Row, int Col) GetIndex(int[][] board, int n)
        {
            n--;
            int row = n / board.Length;
            int col = n % board.Length;

            if ((row & 1) != 0)
            {
                col = board.Length - col - 1;
            }
            row = board.Length - row - 1;
            return (row, col);
        }
    }
}

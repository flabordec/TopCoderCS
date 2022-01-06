using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.SudokuSolver
{
    public class Solution
    {
        int[] rowC = new int[9];
        int[] colC = new int[9];
        int[] squareC = new int[9];
        bool[,] rows = new bool[9, 9];
        bool[,] columns = new bool[9, 9];
        bool[,] squares = new bool[9, 9];
        public void SolveSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                rowC[i] = 9;
                colC[i] = 9;
                squareC[i] = 9;

                for (int j = 0; j < 9; j++)
                {
                    rows[i, j] = true;
                    columns[i, j] = true;
                    squares[i, j] = true;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char currChar = board[i][j];
                    if (currChar != '.')
                    {
                        int value = (currChar - '0') - 1;

                        rows[i, value] = false;
                        rowC[i]--;

                        columns[j, value] = false;
                        colC[j]--;

                        int squareIx = GetSquare(i, j);
                        squares[squareIx, value] = false;
                        squareC[squareIx]--;
                    }
                }
            }

            SolveSudokuRecursive(board, 0, 0);
        }

        public bool SolveSudokuRecursive(char[][] board, int i, int j)
        {
            // PrintBoard(board);
            if (i == -1 && j == -1)
            {
                return true;
            }
            else if (board[i][j] == '.')
            {
                for (int value = 0; value < 9; value++)
                {
                    int s = GetSquare(i, j);
                    if (rows[i, value] == true &&
                        columns[j, value] == true &&
                        squares[s, value] == true)
                    {
                        rows[i, value] = false;
                        columns[j, value] = false;
                        squares[s, value] = false;
                        board[i][j] = (char)('0' + value + 1);
                        GetNextIndices(i, j, out int ni, out int nj);
                        bool currSolve = SolveSudokuRecursive(board, ni, nj);
                        if (currSolve)
                            return true;

                        board[i][j] = '.';
                        rows[i, value] = true;
                        columns[j, value] = true;
                        squares[s, value] = true;
                    }
                }
                // did not find any solution with this square
                return false;
            }
            else
            {
                GetNextIndices(i, j, out int ni, out int nj);
                return SolveSudokuRecursive(board, ni, nj);
            }
        }

        public void PrintBoard(char[][] board)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    builder.Append(board[i][j] + " ");
                }
                builder.AppendLine();
            }
            Console.WriteLine(builder.ToString());
        }

        public void GetNextIndices(int i, int j, out int ni, out int nj)
        {
            ni = i;
            nj = j;
            nj++;
            if (nj == 9)
            {
                ni++;
                nj = 0;
                if (ni == 9)
                {
                    ni = -1;
                    nj = -1;
                }
            }
        }

        public int GetSquare(int row, int column)
        {
            if (row >= 0 && row <= 2)
            {
                if (column >= 0 && column <= 2)
                {
                    return 0;
                }
                else if (column >= 3 && column <= 5)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else if (row >= 3 && row <= 5)
            {
                if (column >= 0 && column <= 2)
                {
                    return 3;
                }
                else if (column >= 3 && column <= 5)
                {
                    return 4;
                }
                else
                {
                    return 5;
                }
            }
            else
            {
                if (column >= 0 && column <= 2)
                {
                    return 6;
                }
                else if (column >= 3 && column <= 5)
                {
                    return 7;
                }
                else
                {
                    return 8;
                }
            }
        }
    }
}

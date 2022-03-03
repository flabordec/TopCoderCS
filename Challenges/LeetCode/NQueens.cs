using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.NQueens
{
    public class Solution
    {
        int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dy = { 1, 0, -1, 1, -1, 1, 0, -1 };

        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> solutions = new List<IList<string>>();
            char[][] board = new char[n][];
            int[][] blocked = new int[n][];
            for (int i = 0; i < n; i++) 
            {
                board[i] = new char[n];
                for (int j = 0; j < board[i].Length; j++)
                {
                    board[i][j] = '.';
                }
                blocked[i] = new int[n];
            }
            BackTrack(n, 0, board, blocked, solutions);
            return solutions;
        }

        public void BackTrack(int n, int ix, char[][] board, int[][] blocked, IList<IList<string>> solutions)
        {
            if (ix == n)
            {
                var sBoard = new List<string>(n);
                for (int i = 0; i < n; i++)
                {
                    sBoard.Add(new string(board[i]));
                }
                solutions.Add(sBoard);
                return;
            }

            for (int iy = 0; iy < n; iy++)
            {
                if (blocked[ix][iy] == 0)
                {
                    board[ix][iy] = 'Q';
                    blocked[ix][iy]++;
                    for (int d = 0; d < dx.Length; d++)
                    {
                        int iix = ix;
                        int iiy = iy;
                        for (int j = 0; j < n; j++)
                        {
                            iix += dx[d];
                            iiy += dy[d];
                            if (iix < 0 || iix >= n ||
                                iiy < 0 || iiy >= n)
                            {
                                break;
                            }
                            blocked[iix][iiy]++;
                        }
                    }
                    BackTrack(n, ix + 1, board, blocked, solutions);
                    blocked[ix][iy]--;
                    for (int d = 0; d < dx.Length; d++)
                    {
                        int iix = ix;
                        int iiy = iy;
                        for (int j = 0; j < n; j++)
                        {
                            iix += dx[d];
                            iiy += dy[d];
                            if (iix < 0 || iix >= n ||
                                iiy < 0 || iiy >= n)
                            {
                                break;
                            }
                            blocked[iix][iiy]--;
                        }
                    }
                    board[ix][iy] = '.';
                }
            }
        }
    }
}

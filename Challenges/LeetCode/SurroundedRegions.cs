using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.SurroundedRegions
{
    public class Solution
    {
        public class Node
        {
            public int I { get; }
            public int J { get; }
            public Node(int i, int j)
            {
                I = i;
                J = j;
            }
        }

        public void Solve(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        Search(i, j, board);
                    }
                }
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 'o')
                    {
                        board[i][j] = 'O';
                    }
                }
            }
        }

        int[] _di = new int[] { -1, 1, 0, 0 };
        int[] _dj = new int[] { 0, 0, -1, 1 };

        public void PrintBoard(char[][] board)
        {
            Console.WriteLine(GetBoard(board));
        }

        public string GetBoard(char[][] board)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < board.Length; i++)
            {
                s.AppendLine(new string(board[i]));
            }
            return s.ToString();
        }

        public void Search(int i, int j, char[][] board)
        {
            bool surrounded = true;
            var queue = new Queue<Node>();
            board[i][j] = 'o';
            queue.Enqueue(new Node(i, j));
            while (queue.Any())
            {
                var curr = queue.Dequeue();

                for (int d = 0; d < _di.Length; d++)
                {
                    int ni = curr.I + _di[d];
                    int nj = curr.J + _dj[d];

                    if (ni < 0 || ni >= board.Length ||
                        nj < 0 || nj >= board[ni].Length)
                    {
                        surrounded = false;
                        continue;
                    } 
                    else if (board[ni][nj] == 'O')
                    {
                        board[ni][nj] = 'o';
                        queue.Enqueue(new Node(ni, nj));
                    }
                }
            }

            if (surrounded)
            {
                board[i][j] = 'X';
                queue.Enqueue(new Node(i, j));
                while (queue.Any())
                {
                    var curr = queue.Dequeue();

                    for (int d = 0; d < _di.Length; d++)
                    {
                        int ni = curr.I + _di[d];
                        int nj = curr.J + _dj[d];

                        if (ni < 0 || ni >= board.Length ||
                            nj < 0 || nj >= board[ni].Length)
                        {
                            continue;
                        }
                        else if (board[ni][nj] == 'o')
                        {
                            board[ni][nj] = 'X';
                            queue.Enqueue(new Node(ni, nj));
                        }
                    }
                }
            }
        }
    }
}

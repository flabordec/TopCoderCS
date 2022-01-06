using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.NumberOfIslands
{
    public class SolutionBfs
    {
        int[] di = { 1, -1, 0, 0 };
        int[] dj = { 0, 0, 1, -1 };

        public int NumIslands(char[][] grid)
        {
            int islands = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        Bfs(grid, i, j);
                        islands++;
                    }
                }
            }

            return islands;
        }

        private void Bfs(char[][] grid, int si, int sj)
        {
            var queue = new Queue<(int I, int J)>();
            grid[si][sj] = '0';
            queue.Enqueue((si, sj));
            while (queue.Any())
            {
                (int ci, int cj) = queue.Dequeue();

                for (int d = 0; d < di.Length; d++)
                {
                    int ni = ci + di[d];
                    int nj = cj + dj[d];

                    if (ni >= 0 && ni < grid.Length &&
                        nj >= 0 && nj < grid[ni].Length &&
                        grid[ni][nj] == '1')
                    {
                        grid[ni][nj] = '0';
                        queue.Enqueue((ni, nj));
                    }
                }
            }
        }
    }

    public class SolutionRecursive
    {
        int[] di = { 1, -1, 0, 0 };
        int[] dj = { 0, 0, 1, -1 };

        public int NumIslands(char[][] grid)
        {
            int islands = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        Dfs(grid, i, j);
                        islands++;
                    }
                }
            }

            return islands;
        }

        private void Dfs(char[][] grid, int si, int sj)
        {
            grid[si][sj] = '0';

            for (int d = 0; d < di.Length; d++)
            {
                int ni = si + di[d];
                int nj = sj + dj[d];

                if (ni >= 0 && ni < grid.Length &&
                    nj >= 0 && nj < grid[ni].Length &&
                    grid[ni][nj] == '1')
                {
                    Dfs(grid, ni, nj);
                }
            }
        }
    }

    public class SolutionBfsClass
    {
        public class State
        {
            public int I { get; }
            public int J { get; }

            public State(int i, int j)
            {
                I = i;
                J = j;
            }
        }

        int[] di = { 1, -1, 0, 0 };
        int[] dj = { 0, 0, 1, -1 };

        public int NumIslands(char[][] grid)
        {
            int islands = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        Bfs(grid, i, j);
                        islands++;
                    }
                }
            }

            return islands;
        }

        private void Bfs(char[][] grid, int si, int sj)
        {
            var queue = new Queue<State>();
            grid[si][sj] = '0';
            queue.Enqueue(new State(si, sj));
            while (queue.Any())
            {
                State curr = queue.Dequeue();

                for (int d = 0; d < di.Length; d++)
                {
                    int ni = curr.I + di[d];
                    int nj = curr.J + dj[d];

                    if (ni >= 0 && ni < grid.Length &&
                        nj >= 0 && nj < grid[ni].Length &&
                        grid[ni][nj] == '1')
                    {
                        grid[ni][nj] = '0';
                        queue.Enqueue(new State(ni, nj));
                    }
                }
            }
        }
    }
}

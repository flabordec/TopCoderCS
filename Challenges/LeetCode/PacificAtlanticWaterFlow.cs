using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.PacificAtlanticWaterFlow
{
    public class Coordinate
    {
        public int I { get; }
        public int J { get; }

        public Coordinate(int i, int j)
        {
            I = i;
            J = j;
        }
    }
    public class Solution
    {
        int[] di = new int[] { -1, 1, 0, 0 };
        int[] dj = new int[] { 0, 0, -1, 1 };

        public void ConnectToPacific(ref int i) => i |= 1;
        public void ConnectToAtlantic(ref int i) => i |= 2;

        public string GetString(int[][] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    sb.Append(matrix[i][j]);
                    sb.Append(" ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public void Bfs(int[][] matrix, int[][] connected, int si, int sj)
        {
            Queue<Coordinate> queue = new Queue<Coordinate>();
            queue.Enqueue(new Coordinate(si, sj));
            while (queue.Any())
            {
                var curr = queue.Dequeue();
                for (int d = 0; d < di.Length; d++)
                {
                    int ni = curr.I + di[d];
                    int nj = curr.J + dj[d];
                    if (ni < 0 || ni >= matrix.Length)
                        continue;
                    if (nj < 0 || nj >= matrix[ni].Length)
                        continue;

                    if (matrix[curr.I][curr.J] <= matrix[ni][nj])
                    {
                        int oldValue = connected[ni][nj];
                        connected[ni][nj] |= connected[curr.I][curr.J];
                        if (oldValue != connected[ni][nj])
                            queue.Enqueue(new Coordinate(ni, nj));
                    }
                }
            }
        }

        public IList<IList<int>> PacificAtlantic(int[][] matrix)
        {
            if (matrix.Length == 0)
                return new List<IList<int>>();

            int[][] connected = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                connected[i] = new int[matrix[i].Length];
            }
            for (int i = 0; i < connected.Length; i++)
            {
                ConnectToPacific(ref connected[i][0]);
                ConnectToAtlantic(ref connected[i][connected[i].Length - 1]);
            }

            for (int i = 0; i < connected[0].Length; i++)
            {
                ConnectToPacific(ref connected[0][i]);
                ConnectToAtlantic(ref connected[connected.Length - 1][i]);
            }

            for (int i = 0; i < connected.Length; i++)
            {
                Bfs(matrix, connected, i, 0);
                Bfs(matrix, connected, i, connected[i].Length - 1);
            }

            for (int i = 0; i < connected[0].Length; i++)
            {
                Bfs(matrix, connected, 0, i);
                Bfs(matrix, connected, connected.Length - 1, i);
            }

            IList<IList<int>> results = new List<IList<int>>();
            for (int i = 0; i < connected.Length; i++)
            {
                for (int j = 0; j < connected[i].Length; j++)
                {
                    if (connected[i][j] == 3)
                    {
                        results.Add(new List<int>() { i, j });
                    }
                }
            }
            return results;
        }
    }
}

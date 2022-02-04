using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.UniquePaths
{
    public class SolutionMagus
    {
        public int UniquePaths(int m, int n)
        {
            int[,] grid = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                grid[i, 0] = 1;
            }
            for (int j = 0; j < n; j++)
            {
                grid[0, j] = 1;
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    grid[i, j] = grid[i - 1, j] + grid[i, j - 1];
                }
            }
            return grid[m - 1, n - 1];
        }
    }

    public class SolutionNandhini
    {
        public int UniquePaths(int m, int n)
        {
            if (m == 1 || n == 1)
            {
                return 1;
            }

            int[] paths = new int[n];

            for (int row = m - 1; row >= 0; row--)
            {
                for (int col = n - 1; col >= 0; col--)
                {
                    if (row == m - 1 || col == n - 1)
                    {
                        paths[col] = 1;
                    }

                    else
                    {
                        paths[col] = paths[col] + paths[col + 1];
                    }
                }
            }

            return paths[0];
        }
    }

    public class SolutionConnor
    {
        public BigInteger UniquePaths(int m, int n)
        {
            int b = Math.Min(m, n) - 1;
            int a = Math.Max(m, n) - 1 + b;
            return (Factorial(a) / (Factorial(b) * Factorial(a - b)));
        }
        public static BigInteger Factorial(int m)
        {
            BigInteger big = BigInteger.One;
            int n = m;
            while (n > 0)
            {
                big = big * n;
                n--;
            }
            return big;
        }
    }
    
    public class SolutionConnorCached
    {
        public BigInteger UniquePaths(int m, int n)
        {
            int b = Math.Min(m, n) - 1;
            int a = Math.Max(m, n) - 1 + b;

            BigInteger[] cache = new BigInteger[a];

            var (ba, bb, bamb) = Factorial(a, b, a - b);

            return (ba / (bb * bamb));
        }
        public static (BigInteger, BigInteger, BigInteger) Factorial(int m, int b, int amb)
        {
            BigInteger ba = BigInteger.Zero, bb = BigInteger.Zero, bamb = BigInteger.Zero;
            BigInteger big = BigInteger.One;
            for (int i = 2; i <= m; i++)
            {
                big = big * i;
                if (i == b)
                    bb = big;
                if (i == amb)
                    bamb = big;
            }
            ba = big;
            return (ba, bb, bamb);
        }

    }

    public class SolutionDavid
    {
        public int[][] pathsArr = new int[100][];
        public bool precalculated = false;

        public int UniquePaths(int m, int n)
        {
            if (!precalculated)
            {
                for (int i = 0; i < 100; i++) pathsArr[i] = new int[100];

                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        pathsArr[i][j] = (i == 0 || j == 0) ? 1 : pathsArr[i][j - 1] + pathsArr[i - 1][j];
                    }
                }

                precalculated = true;
            }

            return pathsArr[m - 1][n - 1];
        }
    }
}

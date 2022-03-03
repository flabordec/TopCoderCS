using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.SetMatrixZeroes
{
    public class SolutionMemoryHog
    {
        public void SetZeroes(int[][] matrix)
        {
            bool[][] seen = new bool[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
                seen[i] = new bool[matrix[i].Length];

            
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    InnerSetZeroes(i, j, matrix, seen);
                }
            }
        }

        public void InnerSetZeroes(int i, int j, int[][] matrix, bool[][] seen)
        {
            if (seen[i][j])
                return;

            if (matrix[i][j] == 0)
            {
                for (int ni = 0; ni < matrix.Length; ni++)
                {
                    InnerSetZeroes(ni, j, matrix, seen);
                }

                for (int nj = 0; nj < matrix[0].Length; nj++)
                {
                    InnerSetZeroes(i, nj, matrix, seen);
                }
            }
            seen[i][j] = true;
        }
    }

    public class SolutionNPlusMSpace
    {
        public void SetZeroes(int[][] matrix)
        {
            bool[] zeroRows = new bool[matrix.Length];
            bool[] zeroCols = new bool[matrix[0].Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        zeroRows[i] = true;
                        zeroCols[j] = true;
                    }
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                if (zeroRows[i] == true)
                {
                    for (int j = 0; j < matrix[0].Length; j++)
                        matrix[i][j] = 0;

                }
            }

            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (zeroCols[j] == true)
                {
                    for (int i = 0; i < matrix.Length; i++)
                        matrix[i][j] = 0;
                }
            }
        }
    }

    public class SolutionNSpace
    {
        public void SetZeroes(int[][] matrix)
        {
            bool[] zeroCols = new bool[matrix[0].Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                bool anyZeroes = false;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        zeroCols[j] = true;
                        anyZeroes = true;
                    }
                }
                if (anyZeroes)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                        matrix[i][j] = 0;
                }
            }

            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (zeroCols[j] == true)
                {
                    for (int i = 0; i < matrix.Length; i++)
                        matrix[i][j] = 0;
                }
            }
        }
    }

}

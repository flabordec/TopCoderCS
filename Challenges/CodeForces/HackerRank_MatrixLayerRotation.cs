using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class Solution_MatrixLayerRotation
{
    // Complete the matrixRotation function below.
    public static void matrixRotation(int[][] matrix, int r)
    {
        int matrixRows = matrix.Length;
        int matrixCols = matrix[0].Length;
        int maxDepth = (Math.Min(matrixRows, matrixCols) + 1) / 2;
        //matrixRows.Dump();
        //matrixCols.Dump();
        //maxDepth.Dump();

        List<List<int>> expandedRows = new List<List<int>>();
        // Print(matrix);
        for (int depth = 0; depth < maxDepth; depth++)
        {
            // new string('-', 20).Dump();
            // $"Doing depth: {depth}".Dump();

            List<int> row = new List<int>();
            // Add the top row at this depth
            int tr = depth;
            for (int i = depth; i < matrixCols - depth; i++)
            {
                // $"Adding top {tr},{i}: {matrix[tr][i]}".Dump();
                row.Add(matrix[tr][i]);
            }
            // Add the right column
            int rc = matrixCols - depth - 1;
            for (int i = depth + 1; i < matrixRows - depth; i++)
            {
                // $"Adding right {i},{rc}: {matrix[i][rc]}".Dump();
                row.Add(matrix[i][rc]);
            }
            // Add the bottom row
            int br = matrixRows - depth - 1;
            for (int i = matrixCols - depth - 2; i >= depth; i--)
            {
                // $"Adding bottom {br},{i} {matrix[br][i]}".Dump();
                row.Add(matrix[br][i]);
            }
            // Add the left column
            int lc = depth;
            for (int i = matrixRows - depth - 2; i >= depth + 1; i--)
            {
                // $"Adding left {i},{lc}: {matrix[i][lc]}".Dump();
                row.Add(matrix[i][lc]);
            }
            //row.Dump();
            expandedRows.Add(row);
        }

        for (int depth = 0; depth < maxDepth; depth++)
        {
            List<int> row = expandedRows[depth];
            int ni = r % row.Count;

            //$"index: {ni}".Dump();
            //row.Dump();

            // Add the top row at this depth
            for (int i = depth; i < matrixCols - depth; i++)
            {
                matrix[depth][i] = row[ni];
                ni = (ni + 1) % row.Count;
            }
            // Add the right column
            for (int i = depth + 1; i < matrixRows - depth; i++)
            {
                matrix[i][matrixCols - depth - 1] = row[ni];
                ni = (ni + 1) % row.Count;
            }
            // Add the bottom row
            for (int i = matrixCols - depth - 2; i >= depth; i--)
            {
                matrix[matrixRows - depth - 1][i] = row[ni];
                ni = (ni + 1) % row.Count;
            }
            // Add the left column
            for (int i = matrixRows - depth - 2; i >= depth + 1; i--)
            {
                matrix[i][depth] = row[ni];
                ni = (ni + 1) % row.Count;
            }
        }
        Print(matrix);
    }

    public static void Print(int[][] matrix)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                builder.AppendFormat("{0} ", matrix[i][j]);
            }
            builder.AppendLine();
        }
        Console.WriteLine(builder.ToString());
    }

    static void Main(string[] args)
    {
        string[] mnr = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(mnr[0]);

        int n = Convert.ToInt32(mnr[1]);

        int r = Convert.ToInt32(mnr[2]);

        int[][] matrix = new int[m][];

        for (int i = 0; i < m; i++)
        {
            int[] v = Console.ReadLine().TrimEnd().Split(' ').Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToArray();
            matrix[i] = v;
        }

        matrixRotation(matrix, r);
    }
}
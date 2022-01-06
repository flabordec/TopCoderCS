using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class Solution_Bomberman
{
    public static int[] dx = new int[] { -1, 1, 0, 0 };
    public static int[] dy = new int[] { 0, 0, -1, 1 };

    // Complete the bomberMan function below.
    public static string[] bomberMan(int N, string[] grid)
    {
        string[] outGrid = new string[grid.Length];

        if (N <= 1)
            return grid;

        if (N % 2 == 0)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                outGrid[i] = new string('O', grid[i].Length);
            }
            return outGrid;
        }

        int[][] gridExplosions = new int[grid.Length][];
        for (int i = 0; i < gridExplosions.Length; i++)
        {
            gridExplosions[i] = new int[grid[i].Length];
            for (int j = 0; j < gridExplosions[i].Length; j++)
            {
                gridExplosions[i][j] = grid[i][j] == 'O' ? 1 : -1;
            }
        }

        N = ((N - 3) % 4) + 3;
        int n = 2;
        while (n <= N)
        {
            Tick(gridExplosions, n);
            PlantBombs(gridExplosions, n);
            PrintGrid(gridExplosions, n);
            n++;

            if (n > N)
                break;

            Tick(gridExplosions, n);
            Explode(gridExplosions, n);
            PrintGrid(gridExplosions, n);
            n++;
        }

        for (int i = 0; i < gridExplosions.Length; i++)
        {
            outGrid[i] = new string(gridExplosions[i].Select(g => (g == -1) ? '.' : 'O').ToArray());
        }

        return outGrid;
    }

    private static void Tick(int[][] gridExplosions, int n)
    {
        for (int i = 0; i < gridExplosions.Length; i++)
        {
            for (int j = 0; j < gridExplosions[i].Length; j++)
            {
                if (gridExplosions[i][j] > 0)
                {
                    gridExplosions[i][j]--;
                }
            }
        }
    }

    private static void Explode(int[][] gridExplosions, int n)
    {
        // After one more second, any bombs planted exactly three seconds ago will detonate. Here, Bomberman stands back and observes.
        for (int i = 0; i < gridExplosions.Length; i++)
        {
            for (int j = 0; j < gridExplosions[i].Length; j++)
            {
                if (gridExplosions[i][j] == 0)
                {
                    gridExplosions[i][j] = -1;
                    for (int d = 0; d < dx.Length; d++)
                    {
                        int di = i + dx[d];
                        int dj = j + dy[d];
                        if (di >= 0 && di < gridExplosions.Length &&
                            dj >= 0 && dj < gridExplosions[i].Length &&
                            gridExplosions[di][dj] != 0)
                        {
                            gridExplosions[di][dj] = -1;
                        }
                    }
                }
            }
        }
        
    }

    private static void PrintGrid(int[][] gridExplosions, int n)
    {
        StringBuilder s = new StringBuilder();
        s.AppendLine($"t = {n}");
        for (int i = 0; i < gridExplosions.Length; i++)
        {
            for (int j = 0; j < gridExplosions[i].Length; j++)
            {
                s.Append($"{gridExplosions[i][j],-3} ");
            }
            s.AppendLine();
        }
        s.AppendLine();

        Console.WriteLine(s.ToString());
    }

    private static void PlantBombs(int[][] gridExplosions, int n)
    {
        // After one more second, Bomberman plants bombs in all cells without bombs, thus filling the whole grid with bombs. No bombs detonate at this point.
        for (int i = 0; i < gridExplosions.Length; i++)
        {
            for (int j = 0; j < gridExplosions[i].Length; j++)
            {
                if (gridExplosions[i][j] == -1)
                {
                    gridExplosions[i][j] = 3;
                }
            }
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] rcn = Console.ReadLine().Split(' ');

        int r = Convert.ToInt32(rcn[0]);
        int c = Convert.ToInt32(rcn[1]);
        int n = Convert.ToInt32(rcn[2]);

        string[] grid = new string[r];

        for (int i = 0; i < r; i++)
        {
            string gridItem = Console.ReadLine();
            grid[i] = gridItem;
        }

        string[] result = bomberMan(n, grid);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}

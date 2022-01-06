using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

public class Solution_EmaSupercomputer
{
    class Point
        : IEquatable<Point>
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }

    class Cross
    {
        public int CenterX { get; }
        public int CenterY { get; }
        public int Length { get; }
        public int Area { get; }
        public HashSet<Point> Points { get; }

        public Cross(int centerX, int centerY, int length)
        {
            CenterX = centerX;
            CenterY = centerY;
            Length = length;
            Area = (length * 4) + 1;
            Points = new HashSet<Point>();
            Points.Add(new Point(CenterX, CenterY));
            for (int s = 1; s <= length; s++)
            {
                for (int d = 0; d < 4; d++)
                {
                    int ny = CenterY + s * dy[d];
                    int nx = CenterX + s * dx[d];
                    Points.Add(new Point(nx, ny));
                }
            }
        }

        public bool Intersects(Cross other)
        {
            HashSet<Point> points = new HashSet<Point>(Points);
            points.IntersectWith(other.Points);
            return points.Any();
        }
    }

    public static int[] dx = new int[] {-1, 1, 0, 0};
    public static int[] dy = new int[] {0, 0, -1, 1};

    // Complete the twoPluses function below.
    public static int twoPluses(string[] grid)
    {
        List<Cross> crosses = new List<Cross>();
        

        int maxY = grid.Length;
        int maxX = grid[0].Length;

        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[y].Length; x++)
            {
                if (grid[y][x] == 'G')
                {
                    crosses.Add(new Cross(x, y, 0));

                    for (int s = 1; s < 15; s++)
                    {
                        bool valid = true;
                        for (int d = 0; d < 4; d++)
                        {
                            int ny = y + s * dy[d];
                            int nx = x + s * dx[d];
                            if (nx < 0 || nx >= maxX || ny < 0 || ny >= maxY || grid[ny][nx] == 'B')
                            {
                                valid = false;
                                break;
                            }
                        }

                        if (valid)
                        {
                            crosses.Add(new Cross(x, y, s));
                            Console.WriteLine($"Cross in {x},{y} length {s}");
                        }
                        else
                            break;
                    }
                }
            }
        }

        int maxArea = 0;
        for (int i = 0; i < crosses.Count; i++)
        {
            for (int j = i + 1; j < crosses.Count; j++)
            {
                if (!crosses[i].Intersects(crosses[j]))
                {
                    int area = crosses[i].Area * crosses[j].Area;
                    maxArea = Math.Max(area, maxArea);
                }
            }
        }

        return maxArea;
    }

    public static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        string[] grid = new string [n];

        for (int i = 0; i < n; i++) {
            string gridItem = Console.ReadLine();
            grid[i] = gridItem;
        }

        int result = twoPluses(grid);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

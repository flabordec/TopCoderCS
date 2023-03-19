using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.HackerRank.TheQuickestWayUp
{
    class Solution
    {
        static void Main(String[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                int steps = SolveOne();
                Console.WriteLine(steps);
            }
        }

        private static int SolveOne()
        {
            int[] graph = new int[101];

            int from, to;

            int L = int.Parse(Console.ReadLine());
            for (int l = 0; l < L; l++)
            {
                ReadLine(out from, out to);
                graph[from] = to;
            }

            int S = int.Parse(Console.ReadLine());
            for (int s = 0; s < S; s++)
            {
                ReadLine(out from, out to);
                graph[from] = to;
            }

            bool[] visited = new bool[101];
            var queue = new Queue<State>();
            queue.Enqueue(new State(1, 0));
            visited[1] = true;
            while (queue.Any())
            {
                State curr = queue.Dequeue();

                for (int i = 1; i <= 6; i++)
                {
                    int next = curr.Square + i;
                    if (next > 100)
                        continue;

                    if (visited[next])
                        continue;
                    visited[next] = true;

                    if (graph[next] != 0)
                        next = graph[next];

                    if (next == 100)
                        return curr.Steps + 1;

                    queue.Enqueue(new State(next, curr.Steps + 1));
                }
            }

            return -1;
        }

        private static void ReadLine(out int from, out int to)
        {
            string line = Console.ReadLine();
            string[] lineSplit = line.Split(' ');
            from = int.Parse(lineSplit[0]);
            to = int.Parse(lineSplit[1]);
        }
    }

    internal class State
    {
        public int Square { get; }
        public int Steps { get; }

        public State(int square, int steps)
        {
            this.Square = square;
            this.Steps = steps;
        }
    }
}
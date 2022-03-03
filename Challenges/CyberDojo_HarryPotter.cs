using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenges.Algorithms;

namespace CyberDojo_HarryPotter_Easy
{
    class State
    {
        public int Index1 { get; }
        public int Index2 { get; }

        /// <inheritdoc />
        public State(int index1, int index2)
        {
            Index1 = index1;
            Index2 = index2;
        }
    }

    public class CyberDojo_HarryPotter
    {
        public double MinPrice(int totalBooks, double[] discounts)
        {
            var minCost = new double[totalBooks + 1];
            var previousStates = new State[totalBooks + 1];
            minCost[0] = 0;
            for (int i = 1; i <= discounts.Length; i++)
            {
                minCost[i] = (i * 8) * (1.0 - discounts[i - 1]);
                previousStates[i] = new State(0, 0);
            }
            for (int i = discounts.Length + 1; i <= totalBooks; i++)
            {
                minCost[i] = double.PositiveInfinity;
                for (int j = 0; j < i / 2; j++)
                {
                    int ix1 = i - j - 1;
                    int ix2 = j + 1;
                    double currentCost = minCost[ix1] + minCost[ix2];
                    if (minCost[i] > currentCost)
                    {
                        minCost[i] = currentCost;
                        previousStates[i] = new State(ix1, ix2);
                    }
                }
            }

            for (int i = 0; i <= totalBooks; i++)
            {
                Console.WriteLine($"{i,5} => {minCost[i],8} => {FindStates(previousStates, i, discounts.Length)}");
            }

            return minCost[totalBooks];
        }

        private string FindStates(State[] states, int i, int numDiscounts)
        {
            List<int> previousStates = new List<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(i);
            while (queue.Any())
            {
                int state = queue.Dequeue();
                if (state == 0)
                    continue;

                if (state <= numDiscounts)
                    previousStates.Add(state);

                queue.Enqueue(states[state].Index1);
                queue.Enqueue(states[state].Index2);
            }

            previousStates.Sort();
            return $"[{string.Join(",", previousStates)}]";
        }
    }
}

namespace CyberDojo_HarryPotter
{
    class State
    {
        public double Cost { get; }
        public int[] BooksLeft { get; }

        /// <inheritdoc />
        public State(double cost, int[] booksLeft)
        {
            Cost = cost;
            BooksLeft = booksLeft;
        }
    }

    public class CyberDojo_HarryPotter
    {
        public double MinPrice(int[] bookCounts, double[] discounts)
        {
            

            return 0.0;
        }

        
    }
}
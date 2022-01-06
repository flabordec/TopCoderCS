using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeForces
{
    class David_Valleys
    {
        const int N = 1000000;
        static int[] largestAfter = new int[N];
        static int[] largestBefore = new int[N];

        static void Main(string[] args)
        {
            while (true)
            {
                int[] numbers = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
                if (!numbers.Any())
                    break;

                Console.WriteLine(FindLargestValley(numbers));
            }
        }

        private static int FindLargestValley(int[] numbers)
        {
            int largest;

            largest = 0;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                largest = Math.Max(largest, numbers[i]);
                largestAfter[i] = largest;
            }

            largest = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                largest = Math.Max(largest, numbers[i]);
                largestBefore[i] = largest;
            }

            largest = 0;
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                // If it is a valley
                if (numbers[i - 1] > numbers[i] && numbers[i] < largestAfter[i])
                {
                    largest = Max(
                        largest,
                        numbers[i - 1] - numbers[i],
                        largestAfter[i] - numbers[i]);
                }
                if (numbers[i+1] > numbers[i] && numbers[i] < largestBefore[i])
                {
                    largest = Max(
                        largest,
                        numbers[i + 1] - numbers[i],
                        largestBefore[i] - numbers[i]);
                }
            }

            return largest;
        }

        private static int Max(int firstValue, params int[] values)
        {
            int max = firstValue;
            for (int i = 0; i < values.Length; i++)
            {
                max = Math.Max(max, values[i]);
            }
            return max;
        }
    }

}

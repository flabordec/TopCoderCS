using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.WateringPlants
{
    public class SolutionIncrement
    {
        public int WateringPlants(int[] plants, int capacity)
        {
            int steps = 0;
            int capacityLeft = capacity;
            for (int i= 0; i < plants.Length - 1; i++)
            {
                steps++;
                capacityLeft -= plants[i];
                
                if (capacityLeft < plants[i + 1])
                {
                    steps += ((i + 1) * 2);
                    capacityLeft = capacity;
                }
            }
            steps++;
            return steps;
        }
    }

    public class SolutionNoIncrement
    {
        public int WateringPlants(int[] plants, int capacity)
        {
            int steps = plants.Length;
            int capacityLeft = capacity;
            for (int i = 0; i < plants.Length - 1; i++)
            {
                capacityLeft -= plants[i];

                if (capacityLeft < plants[i + 1])
                {
                    steps += ((i + 1) * 2);
                    capacityLeft = capacity;
                }
            }
            return steps;
        }
    }
}

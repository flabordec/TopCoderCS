using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.FindCityWithSmallestNumberNeighborsThresholdDistance
{
    public class Solution
    {
        public int FindTheCity(int n, int[][] edges, int distanceThreshold)
        {
            int[,] distances = new int[n, n];
            for (int i = 0;i < n; i++)
                for (int j = 0; j < n; j++)
                    distances[i, j] = -1;

            for (int i = 0; i < edges.Length; i++)
            {
                int from = edges[i][0];
                int to = edges[i][1];
                int dist = edges[i][2];

                distances[from, to] = dist;
                distances[to, from] = dist;
            }

            for (int i = 0; i < n; i++)
            {
                distances[i, i] = 0;
            }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (distances[i,k] == -1 || distances[k,j] == -1)
                            continue;

                        if (distances[i, j] == -1)
                            distances[i, j] = distances[i, k] + distances[k, j];
                        else
                            distances[i, j] = Math.Min(
                                distances[i, j], 
                                distances[i, k] + distances[k, j]);
                    }
                }
            }

            int minCity = -1;
            int minCount = int.MaxValue;
            for (int i= 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        continue;

                    if (distances[i,j] <= distanceThreshold)
                    {
                        count++;
                    }
                }
                if (count <= minCount)
                {
                    minCity = i;
                    minCount = count;
                }
            }

            return minCity;
        }
    }
}
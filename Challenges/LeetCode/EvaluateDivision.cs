using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.EvaluateDivision
{
    public class Solution_FloydWarshall
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries, int n)
        {
            var matrix = new double[n + 1, n + 1];
            for (int i = 0; i < n + 1; i++)
                for (int j = 0; j < n + 1; j++)
                    matrix[i, j] = -1;

            var equationsToIndices = new Dictionary<string, int>();
            int nextIndex = 0;
            for (int i = 0; i < equations.Count; i++)
            {
                string firstPart = equations[i][0];
                string secondPart = equations[i][1];

                double value = values[i];

                if (!equationsToIndices.ContainsKey(firstPart))
                {
                    matrix[nextIndex, nextIndex] = 1;
                    equationsToIndices.Add(firstPart, nextIndex++);
                }

                if (!equationsToIndices.ContainsKey(secondPart))
                {
                    matrix[nextIndex, nextIndex] = 1;
                    equationsToIndices.Add(secondPart, nextIndex++);
                }

                int firstIndex = equationsToIndices[firstPart];
                int secondIndex = equationsToIndices[secondPart];

                matrix[firstIndex, secondIndex] = value;
                matrix[secondIndex, firstIndex] = 1 / value;
            }

            for (int k = 0; k < nextIndex; k++)
            {
                for (int i = 0; i < nextIndex; i++)
                {
                    if (i == k)
                        continue;

                    for (int j = 0; j < nextIndex; j++)
                    {
                        if (j == i || j == k)
                            continue;

                        if (matrix[i, k] == -1 || matrix[k, j] == -1)
                            continue;

                        if (matrix[i, j] == -1)
                            matrix[i, j] = matrix[i, k] * matrix[k, j];
                    }
                }
            }

            double[] results = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                string firstPart = queries[i][0];
                string secondPart = queries[i][1];

                if (equationsToIndices.ContainsKey(firstPart) &&
                    equationsToIndices.ContainsKey(secondPart))
                {
                    int firstIndex = equationsToIndices[firstPart];
                    int secondIndex = equationsToIndices[secondPart];
                    results[i] = matrix[firstIndex, secondIndex];
                }
                else
                {
                    results[i] = -1;
                }
            }
            return results;
        }
    }

    public class Solution_Dfs
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var equationsMap = new Dictionary<string, Dictionary<string, double>>();
            for (int i = 0; i < equations.Count; i++)
            {
                string firstPart = equations[i][0];
                string secondPart = equations[i][1];

                double value = values[i];

                if (!equationsMap.ContainsKey(firstPart))
                {
                    equationsMap.Add(firstPart, new Dictionary<string, double>());
                }
                equationsMap[firstPart][secondPart] = value;

                if (!equationsMap.ContainsKey(secondPart))
                {
                    equationsMap.Add(secondPart, new Dictionary<string, double>());
                }
                equationsMap[secondPart][firstPart] = 1.0 / value;
            }

            double[] results = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                string firstPart = queries[i][0];
                string secondPart = queries[i][1];

                results[i] = Dfs(equationsMap, firstPart, secondPart);
            }
            return results;
        }

        private static double Dfs(Dictionary<string, Dictionary<string, double>> equationsMap, string firstPart, string secondPart)
        {
            var seen = new HashSet<string>();
            var stack = new Stack<(string, double)>();
            stack.Push((firstPart, 1));
            while (stack.Any())
            {
                var (currAlpha, currValue) = stack.Pop();
                if (seen.Contains(currAlpha))
                    continue;
                seen.Add(currAlpha);

                if (!equationsMap.ContainsKey(currAlpha))
                    continue;

                if (currAlpha == secondPart)
                {
                    return currValue;
                }

                foreach (var (nextAlpha, nextValue) in equationsMap[currAlpha])
                {
                    stack.Push((nextAlpha, currValue * nextValue));
                }
            }
            return -1;
        }
    }
}

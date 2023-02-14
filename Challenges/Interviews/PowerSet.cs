using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Interviews.PowerSet
{
    public class PowerSet
    {
        public List<List<int>> GeneratePowerSet(HashSet<int> originalSet)
        {
            List<List<int>> powerSet = new List<List<int>>();
            List<int> currentSolution = new List<int>();
            //                       [1, 2, 3],          0,  [...],     [...]
            GeneratePowerSetHelper(originalSet.ToList(), 0, powerSet, currentSolution);
            return powerSet;
        }

        private void GeneratePowerSetHelper(List<int> originalSet, int ix, List<List<int>> output, List<int> currentSolution)
        {
            if (originalSet.Count == ix)
            {
                output.Add(currentSolution);
                return;
            }

            // I did not grab this one
            GeneratePowerSetHelper(originalSet, ix + 1, output, currentSolution);

            // I grabbed the current index
            List<int> nextSolution = new List<int>(currentSolution);
            nextSolution.Add(originalSet[ix]);
            GeneratePowerSetHelper(originalSet, ix + 1, output, nextSolution);
        }
    }
}
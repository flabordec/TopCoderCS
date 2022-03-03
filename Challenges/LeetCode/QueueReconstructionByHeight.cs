using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.QueueReconstructionByHeight
{
    public class Solution
    {
        public const int heightIx = 0;
        public const int tallerIx = 1;

        public class CompareInts : IComparer<int[]>
        {
            public static IComparer<int[]> Instance = new CompareInts();
            public int Compare(int[] x, int[] y)
            {
                if (x[tallerIx] != y[tallerIx])
                {
                    return x[tallerIx] - y[tallerIx];
                }
                else
                {
                    return x[heightIx] - y[heightIx];
                }
            }
        }

        public int[][] ReconstructQueue(int[][] people)
        {
            Array.Sort(people, CompareInts.Instance);

            int c = 0;
            int[][] results = new int[people.Length][];
            for (int i = 0; i < results.Length; i++)
                results[i] = new int[2];

            for (int i = 0; i < people.Length; i++)
            {
                int ix = 0;
                int tallerInFront = 0;
                while (ix < c)
                {
                    if (results[ix][heightIx] >= people[i][heightIx])
                    {
                        tallerInFront++;
                    }
                    if (tallerInFront > people[i][tallerIx])
                    {
                        break;
                    }
                    ix++;
                }

                int nix = c;
                while (nix > ix)
                {
                    results[nix] = results[nix - 1];
                    nix--;
                }

                results[ix] = people[i];
                c++;
            }

            return results;
        }
    }

}

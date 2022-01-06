using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.CouplesHoldingHands
{
    public class Solution
    {
        public int MinSwapsCouples(int[] row)
        {
            int changes = 0;

            for (int i = 0; i < row.Length; i += 2)
            {
                int first = Math.Min(row[i], row[i + 1]);
                int second = Math.Max(row[i], row[i + 1]);

                if (FindPartner(first) == second)
                {
                    // Already in place 
                    continue;
                }
                else
                {
                    int partnerFirst = FindPartner(first);
                    int partnerSecond = FindPartner(second);
                    for (int j = i + 2; j < row.Length; j += 2)
                    {
                        int swapFirst = row[j];
                        int swapSecond = row[j + 1];
                        if (swapFirst == partnerFirst || swapSecond == partnerFirst ||
                            swapFirst == partnerSecond || swapSecond == partnerSecond)
                        {
                            // Swap either of them for their partner
                            changes++;
                            if (FindPartner(row[i]) == row[j])
                            {
                                Swap(row, i + 1, j);
                            }
                            else if (FindPartner(row[i]) == row[j + 1])
                            {
                                Swap(row, i + 1, j + 1);
                            }
                            else if (FindPartner(row[i + 1]) == row[j])
                            {
                                Swap(row, i, j);
                            }
                            else if (FindPartner(row[i + 1]) == row[j + 1])
                            {
                                Swap(row, i, j + 1);
                            }
                            break;
                        }
                    }
                }
            }

            return changes;
        }

        public int FindPartner(int n) => (n & 1) == 0 ? n + 1 : n - 1;

        public void Swap(int[] row, int i1, int i2)
        {
            int temp = row[i1];
            row[i1] = row[i2];
            row[i2] = temp;
        }
    }

    public class SolutionForLoop
    {
        public int MinSwapsCouples(int[] row)
        {
            int changes = 0;

            for (int i = 0; i < row.Length; i += 2)
            {
                int first = row[i];
                int second = row[i + 1];

                if (FindPartner(first) == second)
                {
                    // Already in place 
                    continue;
                }
                else
                {
                    int partnerFirst = FindPartner(first);
                    int partnerSecond = FindPartner(second);
                    for (int j = i + 2; j < row.Length; j++)
                    {
                        int swapFirst = row[j];
                        if (swapFirst == partnerFirst || swapFirst == partnerSecond )
                        {
                            // Swap them for their partner
                            changes++;
                            if (FindPartner(row[i]) == row[j])
                            {
                                Swap(row, i + 1, j);
                            }
                            else if (FindPartner(row[i]) == row[j + 1])
                            {
                                Swap(row, i + 1, j + 1);
                            }
                            break;
                        }
                    }
                }
            }

            return changes;
        }

        public int FindPartner(int n) => (n & 1) == 0 ? n + 1 : n - 1;

        public void Swap(int[] row, int i1, int i2)
        {
            int temp = row[i1];
            row[i1] = row[i2];
            row[i2] = temp;
        }
    }

    public class SolutionDictionaryMagus
    {
        public int MinSwapsCouples(int[] row)
        {
            int changes = 0;

            var numberToIndex = new Dictionary<int, int>();
            for (int i = 0; i < row.Length; i++)
            {
                numberToIndex[row[i]] = i;
            }

            for (int i = 0; i < row.Length; i += 2)
            {
                int first = row[i];
                int second = row[i + 1];

                int partnerFirst = FindPartner(first);
                if (partnerFirst == second)
                {
                    // Already in place 
                    continue;
                }
                else
                {
                    int indexPartner = numberToIndex[partnerFirst];
                    Swap(row, numberToIndex, i + 1, indexPartner);
                    changes++;
                }
            }

            return changes;
        }

        public int FindPartner(int n) => (n & 1) == 0 ? n + 1 : n - 1;

        public void Swap(int[] row, Dictionary<int, int> numberToIndex, int i1, int i2)
        {
            int v1 = row[i1];
            int v2 = row[i2];

            numberToIndex[v1] = i2;
            numberToIndex[v2] = i1;

            int temp = row[i1];
            row[i1] = row[i2];
            row[i2] = temp;
        }
    }

    public class SolutionDictionaryJeff
    {
        public int MinSwapsCouples(int[] row)
        {
            int swaps = 0;
            Dictionary<int, int> numberToIndex = new Dictionary<int, int>();
            for (int i = 0; i < row.Length; i++)
            {
                numberToIndex[row[i]] = i;
            }

            for (int i = 0; i < row.Length; i += 2)
            {
                int coupleIdA = row[i] / 2;

                int coupleIdB = row[i + 1] / 2;

                if (coupleIdA == coupleIdB)
                    continue;

                bool aIsEven = row[i] % 2 == 0;
                int partner = coupleIdA * 2;
                if (aIsEven)
                    partner++;

                int indexOfPartner = numberToIndex[partner];
                int valueOfB = row[i + 1];
                
                row[i + 1] = partner;
                row[indexOfPartner] = valueOfB;
                
                numberToIndex[partner] = i + 1;
                numberToIndex[valueOfB] = indexOfPartner;
                
                swaps++;
            }

            return swaps;
        }
    }
}

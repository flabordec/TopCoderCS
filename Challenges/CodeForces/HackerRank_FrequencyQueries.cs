using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

class Solution_FrequencyQueries
{
    // Complete the freqQuery function below.
    static List<int> freqQuery(List<List<int>> queries)
    {
        var numbers = new Dictionary<long, long>();
        var frequencies = new Dictionary<long, long>();
        List<int> output = new List<int>();

        foreach (var query in queries)
        {
            int q = query[0];
            int n = query[1];
            long frequency = 0;
            if (q == 1 || q == 2)
            {
                if (!numbers.ContainsKey(n))
                {
                    numbers.Add(n, 0);
                }
                frequency = numbers[n];
            }
            switch (q)
            {
                case 1:
                    // 1- : Insert x in your data structure.
                    if (frequency != 0)
                    {
                        if (!frequencies.ContainsKey(frequency))
                            frequencies.Add(frequency, 0);

                        frequencies[frequency]--;
                    }
                    if (!frequencies.ContainsKey(frequency + 1))
                        frequencies.Add(frequency + 1, 0);
                    frequencies[frequency + 1]++;

                    numbers[n]++;

                    //$"Add {n}".Dump();
                    //numbers.Dump();
                    //frequencies.Dump();
                    break;

                case 2:
                    // 2 - : Delete one occurence of y from your data structure, if present.
                    if (numbers[n] > 0)
                    {
                        frequencies[frequency]--;
                        if (frequency - 1 != 0)
                        {
                            frequencies[frequency - 1]++;
                        }


                        numbers[n]--;
                    }

                    //$"Delete {n}".Dump();
                    //numbers.Dump();
                    //frequencies.Dump();
                    break;

                case 3:
                    //$"Check {n}".Dump();

                    // 3- : Check if any integer is present whose frequency is exactly.If yes, print 1 else 0.
                    if (frequencies.ContainsKey(n) && frequencies[n] > 0)
                    {
                        //$"Found {frequencies[n]}".Dump();
                        output.Add(1);
                    }
                    else
                    {
                        //$"Not found".Dump();
                        output.Add(0);
                    }
                    break;
            }
        }

        return output;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> ans = freqQuery(queries);

        textWriter.WriteLine(String.Join("\n", ans));

        textWriter.Flush();
        textWriter.Close();
    }
}
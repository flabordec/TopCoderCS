using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub
{
    public class SetAlarms
    {
        public static string Solve(string filePath)
        {
            using (var file = new StreamReader(File.OpenRead(filePath)))
            {
                string[] firstLine = file.ReadLine().Split(' ');
                int N = int.Parse(firstLine[0]);
                int A = int.Parse(firstLine[1]);

                string[] instrumentIds = new string[N];
                var instruments = new Dictionary<string, HashSet<int>>();
                for (int i = 0; i < N; i++)
                {
                    string line = file.ReadLine();
                    instruments.Add(line, new HashSet<int>());
                    instrumentIds[i] = line;
                }

                for (int i = 0; i < A; i++)
                {
                    string[] line = file.ReadLine().Split(' ');
                    string instrumentId = line[0];
                    int alarm = int.Parse(line[1]);
                    instruments[instrumentId].Add(alarm);
                }

                var s = new StringBuilder();
                foreach (string instrumentId in instrumentIds)
                {
                    var orderedAlarms = instruments[instrumentId].OrderBy(a => a);
                    s.AppendLine($"{instrumentId} {string.Join(" ", orderedAlarms)}");
                }
                return s.ToString();
            }
        }
    }
}

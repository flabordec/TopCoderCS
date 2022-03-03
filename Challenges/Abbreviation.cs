using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Runtime.InteropServices;

namespace Challenges
{
    public class Abbreviation
    {
        private static bool[][] cache;

        // Complete the abbreviation function below.
        public static string Solve(string a, string b)
        {
            cache = new bool[a.Length][];
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = new bool[b.Length];
            }

            bool value = false;
            for (int ai = 0; ai < a.Length; ai++)
            {
                if (char.ToUpper(a[ai]) == b[0])
                {
                    value = true;
                }
                else if (char.IsUpper(a[ai]))
                {
                    value = false;
                }

                cache[ai][0] = value;
            }

            for (int bi = 1; bi < b.Length; bi++)
            {
                value = false;
                for (int ai = 1; ai < a.Length; ai++)
                {
                    if (cache[ai - 1][bi - 1] == true &&
                        char.ToUpper(a[ai]) == b[bi])
                    {
                        value = true;
                    }
                    else if (char.IsUpper(a[ai]))
                    {
                        value = false;
                    }

                    cache[ai][bi] = value;
                }

                Console.WriteLine(Print(a, b));
                Console.WriteLine(new string('-', 15));
            }

            return cache[a.Length - 1][b.Length - 1] ? "YES" : "NO";
        }

        public static string Print(string a, string b)
        {
            StringBuilder s = new StringBuilder();
            s.Append("\t");
            for (int bi = 0; bi < b.Length; bi++)
            {
                s.Append(b[bi]);
                s.Append("\t");
            }
            s.AppendLine();

            for (int ai = 0; ai < a.Length; ai++)
            {
                s.Append(a[ai]);
                s.Append("\t");

                for (int bi = 0; bi < b.Length; bi++)
                {
                    s.Append(cache[ai][bi] ? "1" : "0");
                    s.Append("\t");
                }

                s.AppendLine();
            }

            return s.ToString();
        }
    }

}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Engines;
using RemovingStarsFromAString;

namespace Benchmark
{
    /*
    | Method |     Mean |    Error |   StdDev |
    |------- |---------:|---------:|---------:|
    |  Array | 17.33 ns | 0.205 ns | 0.181 ns |
    |   List | 75.62 ns | 0.385 ns | 0.342 ns |
    */

    [SimpleJob(RuntimeMoniker.Net60)]
    public class BenchmarkRemovingStarsFromAString
    {
        // We cannot even test large numbers because the trash solution is so trash
        public string s = "leet**cod*e";

        [Benchmark]
        public void Array() => new Solution().RemoveStars(s);

        [Benchmark]
        public void List() => new Solution().RemoveStarsList(s);
    }
}

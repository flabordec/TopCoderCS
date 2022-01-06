using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopCoderCS.LeetCode.StoneGameIII;

namespace Benchmark
{
    /*
    |             Method | _n |        Mean |    Error |   StdDev | Ratio | RatioSD |
    |------------------- |--- |------------:|---------:|---------:|------:|--------:|
    | DynamicProgramming |  5 |   115.14 ns | 1.124 ns | 1.051 ns |  1.00 |    0.00 |
    |              Trash |  5 |    81.01 ns | 0.863 ns | 0.807 ns |  0.70 |    0.01 |
    |                    |    |             |          |          |       |         |
    | DynamicProgramming | 10 |   238.34 ns | 1.123 ns | 0.995 ns |  1.00 |    0.00 |
    |              Trash | 10 | 1,325.70 ns | 5.354 ns | 4.471 ns |  5.56 |    0.03 |
    */

    [SimpleJob(RuntimeMoniker.Net50)]
    public class BenchmarkStoneGameIII
    {
        // We cannot even test large numbers because the trash solution is so trash
        [Params(5, 10/*, 50000*/)]
        public int _n;
        public int[] _stoneValue;

        [GlobalSetup]
        public void GlobalSetup()
        {
            // constant seed so the results are constant
            var random = new Random(314159);
            _stoneValue = new int[_n];
            for (int i= 0; i < _n; i++)
            {
                int value = random.Next(-1000, -1000);
                _stoneValue[i] = value;
            }
        }


        [Benchmark(Baseline = true)]
        public void DynamicProgramming() => new SolutionDynamicProgramming().StoneGameIII(_stoneValue);

        [Benchmark]
        public void Trash() => new SolutionTrash().StoneGameIII(_stoneValue);
    }
}

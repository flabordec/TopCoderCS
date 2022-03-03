using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenges.LeetCode.WateringPlants;

namespace Benchmark
{
    /*
    |      Method |   _n | _happyPath |     Mean |    Error |   StdDev | Ratio | RatioSD |
    |------------ |----- |----------- |---------:|---------:|---------:|------:|--------:|
    |   Increment | 1000 |      False | 875.2 ns |  2.85 ns |  2.66 ns |  1.00 |    0.00 |
    | NoIncrement | 1000 |      False | 660.1 ns |  1.43 ns |  1.27 ns |  0.75 |    0.00 |
    |             |      |            |          |          |          |       |         |
    |   Increment | 1000 |       True | 730.6 ns | 13.51 ns | 12.64 ns |  1.00 |    0.00 |
    | NoIncrement | 1000 |       True | 742.9 ns | 10.50 ns |  9.82 ns |  1.02 |    0.02 |
    */

    [SimpleJob(RuntimeMoniker.Net60)]
    public class BenchmarkWateringPlants
    {
        // We cannot even test large numbers because the trash solution is so trash
        [Params(1000)]
        public int _n;
        [Params(false, true)]
        public bool _happyPath;

        public int[] _plants;
        public int _capacity;

        [GlobalSetup]
        public void GlobalSetup()
        {
            // constant seed so the results are constant
            var random = new Random(314159);
            _plants = new int[_n];
            for (int i = 0; i < _n; i++)
            {
                _plants[i] = _happyPath ? 0 : 1;
            }
            _capacity = 1;
        }

        [Benchmark(Baseline = true)]
        public void Increment() => new SolutionIncrement().WateringPlants(_plants, _capacity);

        [Benchmark]
        public void NoIncrement() => new SolutionNoIncrement().WateringPlants(_plants, _capacity);
    }
}

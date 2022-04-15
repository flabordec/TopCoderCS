using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Engines;
using Challenges.LeetCode.EvaluateDivision;

namespace Benchmark
{
    /*
     * Explosion == false means that we have at most n nodes
    |        Method | _n | _explosion |         Mean |     Error |    StdDev | Ratio | RatioSD |
    |-------------- |--- |----------- |-------------:|----------:|----------:|------:|--------:|
    | FloydWarshall | 10 |      False |     4.918 us | 0.0272 us | 0.0254 us |  1.00 |    0.00 |
    |           Dfs | 10 |      False |     7.938 us | 0.0493 us | 0.0437 us |  1.61 |    0.02 |
    |               |    |            |              |           |           |       |         |
    | FloydWarshall | 10 |       True |     6.904 us | 0.0328 us | 0.0306 us |  1.00 |    0.00 |
    |           Dfs | 10 |       True |    27.347 us | 0.0437 us | 0.0388 us |  3.96 |    0.02 |
    |               |    |            |              |           |           |       |         |
    | FloydWarshall | 20 |      False |    32.081 us | 0.0655 us | 0.0580 us |  1.00 |    0.00 |
    |           Dfs | 20 |      False |    26.319 us | 0.0882 us | 0.0825 us |  0.82 |    0.00 |
    |               |    |            |              |           |           |       |         |
    | FloydWarshall | 20 |       True |    42.670 us | 0.1204 us | 0.1126 us |  1.00 |    0.00 |
    |           Dfs | 20 |       True |   187.643 us | 0.5541 us | 0.5183 us |  4.40 |    0.01 |
    |               |    |            |              |           |           |       |         |
    | FloydWarshall | 50 |      False |   394.066 us | 0.6418 us | 0.5360 us |  1.00 |    0.00 |
    |           Dfs | 50 |      False |   140.353 us | 0.5423 us | 0.5073 us |  0.36 |    0.00 |
    |               |    |            |              |           |           |       |         |
    | FloydWarshall | 50 |       True |   458.448 us | 1.3394 us | 1.2529 us |  1.00 |    0.00 |
    |           Dfs | 50 |       True | 2,437.951 us | 7.3925 us | 5.7716 us |  5.32 |    0.02 |
    */

    [SimpleJob(RuntimeMoniker.Net60)]
    public class BenchmarkEvaluateDivision
    {
        // We cannot even test large numbers because the trash solution is so trash
        [Params(10, 20, 50)]
        public int _n;
        [Params(false, true)]
        public bool _explosion;

        private List<IList<string>> _equations = new List<IList<string>>();
        private double[] _values;
        private List<IList<string>> _queries = new List<IList<string>>();

        [GlobalSetup]
        public void GlobalSetup()
        {
            // constant seed so the results are constant
            var random = new Random(314159);

            _values = new double[_n];
            for (int i = 0; i < _n; i++)
            {
                char c1 = (char)(i + 'a');
                char c2 = (char)(i + 'a' + 1);

                string s1 = new string(c1, 1);
                string s2 = new string(c2, 1);

                _equations.Add(new List<string>() { s1, s2 });
                _values[i] = 1.0;
                if (!_explosion) 
                {
                    _queries.Add(new List<string>() { "a", s2 });
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        char c3 = (char)(j + 'a');
                        string s3 = new string(c3, 1);
                        _queries.Add(new List<string>() { s3, s2 });
                    }
                }
                
            }
        }

        [Benchmark(Baseline = true)]
        public void FloydWarshall() => new Solution_FloydWarshall().CalcEquation(_equations, _values, _queries, _n);

        [Benchmark]
        public void Dfs() => new Solution_Dfs().CalcEquation(_equations, _values, _queries);
    }
}

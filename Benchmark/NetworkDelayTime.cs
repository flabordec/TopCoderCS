using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopCoderCS.LeetCode.NetworkDelayTime;

namespace Benchmark
{
    /*
    |                  Method |  _n | _numVertices |           Mean |       Error |      StdDev | Ratio |
    |------------------------ |---- |------------- |---------------:|------------:|------------:|------:|
    |           FloydWarshall |  50 |           50 |   167,298.1 ns | 1,081.74 ns |   958.93 ns | 1.000 |
    | DijkstraNoPriorityQueue |  50 |           50 |     2,715.2 ns |    11.03 ns |     9.78 ns | 0.016 |
    |                Dijkstra |  50 |           50 |     2,314.7 ns |    17.79 ns |    16.64 ns | 0.014 |
    |    DijkstraNeighborList |  50 |           50 |       841.4 ns |    15.98 ns |    18.41 ns | 0.005 |
    |                         |     |              |                |             |             |       |
    |           FloydWarshall |  50 |         1000 |   761,721.2 ns | 4,522.98 ns | 4,230.80 ns | 1.000 |
    | DijkstraNoPriorityQueue |  50 |         1000 |    12,279.2 ns |   185.88 ns |   164.78 ns | 0.016 |
    |                Dijkstra |  50 |         1000 |    34,126.4 ns |   568.79 ns |   504.22 ns | 0.045 |
    |    DijkstraNeighborList |  50 |         1000 |     6,435.5 ns |   124.87 ns |   122.64 ns | 0.008 |
    |                         |     |              |                |             |             |       |
    |           FloydWarshall |  50 |         6000 |   802,385.2 ns | 6,960.30 ns | 6,510.67 ns |  1.00 |
    | DijkstraNoPriorityQueue |  50 |         6000 |    47,891.4 ns |   700.78 ns |   655.51 ns |  0.06 |
    |                Dijkstra |  50 |         6000 |   165,097.9 ns |   835.17 ns |   781.22 ns |  0.21 |
    |    DijkstraNeighborList |  50 |         6000 |    26,569.5 ns |   325.91 ns |   272.15 ns |  0.03 |
    |                         |     |              |                |             |             |       |
    |           FloydWarshall | 100 |           50 | 1,186,183.1 ns | 8,259.48 ns | 7,321.81 ns | 1.000 |
    | DijkstraNoPriorityQueue | 100 |           50 |    13,013.5 ns |    37.07 ns |    34.67 ns | 0.011 |
    |                Dijkstra | 100 |           50 |     2,986.9 ns |    56.91 ns |    63.25 ns | 0.003 |
    |    DijkstraNeighborList | 100 |           50 |     1,277.9 ns |     8.70 ns |     7.26 ns | 0.001 |
    |                         |     |              |                |             |             |       |
    |           FloydWarshall | 100 |         1000 | 5,107,892.7 ns | 6,132.63 ns | 5,436.42 ns | 1.000 |
    | DijkstraNoPriorityQueue | 100 |         1000 |    28,794.0 ns |   121.81 ns |   107.98 ns | 0.006 |
    |                Dijkstra | 100 |         1000 |    40,014.9 ns |   796.87 ns |   818.33 ns | 0.008 |
    |    DijkstraNeighborList | 100 |         1000 |     7,624.6 ns |    53.77 ns |    47.66 ns | 0.001 |
    |                         |     |              |                |             |             |       |
    |           FloydWarshall | 100 |         6000 | 5,963,839.2 ns | 6,838.37 ns | 5,338.95 ns | 1.000 |
    | DijkstraNoPriorityQueue | 100 |         6000 |    67,945.7 ns | 1,211.74 ns | 1,133.46 ns | 0.011 |
    |                Dijkstra | 100 |         6000 |   225,279.3 ns | 1,294.09 ns | 1,210.50 ns | 0.038 |
    |    DijkstraNeighborList | 100 |         6000 |    32,501.4 ns |   538.61 ns |   503.82 ns | 0.005 |
    */

    [SimpleJob(RuntimeMoniker.Net50)]
    public class BenchmarkNetworkDelayTime
    {
        [Params(50, 100)]
        public int _n;
        [Params(50, 1000, 6000)]
        public int _numVertices;
        public int[][] _times;
        public int _k;

        [GlobalSetup]
        public void GlobalSetup()
        {
            // constant seed so the results are constant
            var random = new Random(314159);

            HashSet<(int, int, int)> truples = new HashSet<(int, int, int)>();
            while (truples.Count < _numVertices)
            {
                int i = random.Next(_n) + 1;
                int j = random.Next(_n) + 1;
                int k = random.Next(_n) + 1;
                var truple = (i, j, k);
                if (!truples.Contains(truple))
                {
                    truples.Add(truple);
                }
            }

            int timesIx = 0;
            _times = new int[_numVertices][];
            foreach (var truple in truples)
            {
                _times[timesIx++] = new int[] { truple.Item1, truple.Item2, truple.Item3 };
            }
            _k = random.Next(_n) + 1;
        }

        [Benchmark(Baseline = true)]
        public void FloydWarshall() => new SolutionFloydWarshall().NetworkDelayTime(_times, _n, _k);

        [Benchmark]
        public void DijkstraNoPriorityQueue() => new SolutionDijkstraNoPriorityQueue().NetworkDelayTime(_times, _n, _k);

        [Benchmark]
        public void Dijkstra() => new SolutionDijkstra().NetworkDelayTime(_times, _n, _k);
    }
}

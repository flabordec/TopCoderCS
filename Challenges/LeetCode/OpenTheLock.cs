using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenges.Algorithms;

namespace Challenges.LeetCode.OpenTheLock
{
    public class SolutionWithTracking
    {
        class State
        {
            public int Value { get; }
            public int Depth { get; }
            public State Previous { get; }

            public State(int value, int depth, State previous)
            {
                Value = value;
                Depth = depth;
                Previous = previous;
            }
        }

        public int OpenLock(string[] deadends, string target)
        {
            var deadendsSet = new HashSet<int>(deadends.Select(d => int.Parse(d)));
            var targetValue = int.Parse(target);

            if (deadendsSet.Contains(0))
                return -1;
            if (targetValue == 0)
                return 0;

            var first = new State(0, 0, null);

            var queue = new Queue<State>();
            queue.Enqueue(first);
            var seen = new HashSet<int>();
            seen.Add(0);
            while (queue.Any())
            {
                State curr = queue.Dequeue();

                if (curr.Value == targetValue)
                {
                    return curr.Depth;
                }

                for (int i = 0; i < 4; i++)
                {
                    int prev = UpdateValue(curr.Value, i, v => v - 1);
                    if (!seen.Contains(prev) && !deadendsSet.Contains(prev))
                    {
                        // Console.WriteLine($"Enqueueing {prev} {curr.Depth + 1}");
                        seen.Add(prev);
                        queue.Enqueue(new State(prev, curr.Depth + 1, curr));
                    }

                    int next = UpdateValue(curr.Value, i, v => v + 1);
                    if (!seen.Contains(next) && !deadendsSet.Contains(next))
                    {
                        // Console.WriteLine($"Enqueueing {next} {curr.Depth + 1}");
                        seen.Add(next);
                        queue.Enqueue(new State(next, curr.Depth + 1, curr));
                    }
                }
            }

            return -1;
        }

        int UpdateValue(int value, int offset, Func<int, int> update)
        {
            int v = value;
            for (int i = 0; i < offset; i++)
            {
                v /= 10;
            }
            v %= 10;
            int uv = update(v);
            uv = (uv + 10) % 10;
            for (int i = 0; i < offset; i++)
            {
                v *= 10;
                uv *= 10;
            }

            int r = value;
            return r - v + uv;
        }
    }

    public class SolutionInts
    {
        class State
        {
            public int Value { get; }
            public int Depth { get; }

            public State(int value, int depth)
            {
                Value = value;
                Depth = depth;
            }
        }

        public int OpenLock(string[] deadends, string target)
        {
            var deadendsSet = new HashSet<int>(deadends.Select(d => int.Parse(d)));
            var targetValue = int.Parse(target);

            if (deadendsSet.Contains(0))
                return -1;
            if (targetValue == 0)
                return 0;

            var first = new State(0, 0);

            var queue = new Queue<State>();
            queue.Enqueue(first);
            var seen = new HashSet<int>();
            seen.Add(0);
            while (queue.Any())
            {
                State curr = queue.Dequeue();

                if (curr.Value == targetValue)
                {
                    return curr.Depth;
                }

                for (int i = 0; i < 4; i++)
                {
                    int prev = UpdateValue(curr.Value, i, v => v - 1);
                    if (!seen.Contains(prev) && !deadendsSet.Contains(prev))
                    {
                        // Console.WriteLine($"Enqueueing {prev} {curr.Depth + 1}");
                        seen.Add(prev);
                        queue.Enqueue(new State(prev, curr.Depth + 1));
                    }

                    int next = UpdateValue(curr.Value, i, v => v + 1);
                    if (!seen.Contains(next) && !deadendsSet.Contains(next))
                    {
                        // Console.WriteLine($"Enqueueing {next} {curr.Depth + 1}");
                        seen.Add(next);
                        queue.Enqueue(new State(next, curr.Depth + 1));
                    }
                }
            }

            return -1;
        }

        int UpdateValue(int value, int offset, Func<int, int> update)
        {
            int v = value;
            for (int i = 0; i < offset; i++)
            {
                v /= 10;
            }
            v %= 10;
            int uv = update(v);
            uv = (uv + 10) % 10;
            for (int i = 0; i < offset; i++)
            {
                v *= 10;
                uv *= 10;
            }

            int r = value;
            return r - v + uv;
        }
    }

    public class SolutionAStar
    {
        private static int _targetValue;

        class State : IComparable<State>
        {
            public int Value { get; }
            public int Depth { get; }

            public State(int value, int depth)
            {
                Value = value;
                Depth = depth;
            }

            public int CompareTo(State other)
            {
                return GetDistance().CompareTo(other.GetDistance());
            }

            int GetDistance()
            {
                int distance = 0;
                int v = Value;
                int t = _targetValue;
                for (int i = 0; i < 4; i++)
                {
                    int vd = v % 10;
                    int td = t % 10;

                    distance += Math.Abs(td - vd);

                    v /= 10;
                    t /= 10;
                }
                return Depth + distance;
            }
        }

        public int OpenLock(string[] deadends, string target)
        {
            var deadendsSet = new HashSet<int>(deadends.Select(d => int.Parse(d)));
            var targetValue = int.Parse(target);

            _targetValue = targetValue;

            if (deadendsSet.Contains(0))
                return -1;
            if (targetValue == 0)
                return 0;

            var first = new State(0, 0);

            var queue = new PriorityQueue<State>();
            queue.Enqueue(first);
            var seen = new HashSet<int>();
            seen.Add(0);
            while (!queue.IsEmpty)
            {
                State curr = queue.DequeueMin();

                if (curr.Value == targetValue)
                {
                    return curr.Depth;
                }

                for (int i = 0; i < 4; i++)
                {
                    int prev = UpdateValue(curr.Value, i, v => v - 1);
                    if (!seen.Contains(prev) && !deadendsSet.Contains(prev))
                    {
                        seen.Add(prev);
                        queue.Enqueue(new State(prev, curr.Depth + 1));
                    }

                    int next = UpdateValue(curr.Value, i, v => v + 1);
                    if (!seen.Contains(next) && !deadendsSet.Contains(next))
                    {
                        seen.Add(next);
                        queue.Enqueue(new State(next, curr.Depth + 1));
                    }
                }
            }

            return -1;
        }

        int UpdateValue(int value, int offset, Func<int, int> update)
        {
            // v == value == 1234
            int v = value;
            for (int i = 0; i < offset; i++)
            {
                v /= 10;
            }
            // v == 12
            v %= 10;
            // v == 2
            int uv = update(v);
            // uv == 3 (update is +1)
            uv = (uv + 10) % 10;
            // uv == 3
            for (int i = 0; i < offset; i++)
            {
                v *= 10;
                uv *= 10;
            }
            // v == 200
            // uv == 300

            // r == 1234
            int r = value;
            // r - 200 + 300 = 1334
            return r - v + uv;
        }
    }

    public class SolutionAStarPrecalc
    {
        private static int _targetValue;

        class State : IComparable<State>
        {
            public int Value { get; }
            public int Depth { get; }
            public int Distance { get; }

            public State(int value, int depth)
            {
                Value = value;
                Depth = depth;
                Distance = GetDistance();
            }

            public int CompareTo(State other)
            {
                return Distance.CompareTo(other.Distance);
            }

            int GetDistance()
            {
                int distance = 0;
                int v = Value;
                int t = _targetValue;
                for (int i = 0; i < 4; i++)
                {
                    int vd = v % 10;
                    int td = t % 10;

                    distance += Math.Abs(td - vd);

                    v /= 10;
                    t /= 10;
                }
                return Depth + distance;
            }
        }

        public int OpenLock(string[] deadends, string target)
        {
            var deadendsSet = new HashSet<int>(deadends.Select(d => int.Parse(d)));
            var targetValue = int.Parse(target);

            _targetValue = targetValue;

            if (deadendsSet.Contains(0))
                return -1;
            if (targetValue == 0)
                return 0;

            var first = new State(0, 0);

            var queue = new PriorityQueue<State>();
            queue.Enqueue(first);
            var seen = new HashSet<int>();
            seen.Add(0);
            while (!queue.IsEmpty)
            {
                State curr = queue.DequeueMin();

                if (curr.Value == targetValue)
                {
                    return curr.Depth;
                }

                for (int i = 0; i < 4; i++)
                {
                    int prev = UpdateValue(curr.Value, i, v => v - 1);
                    if (!seen.Contains(prev) && !deadendsSet.Contains(prev))
                    {
                        seen.Add(prev);
                        queue.Enqueue(new State(prev, curr.Depth + 1));
                    }

                    int next = UpdateValue(curr.Value, i, v => v + 1);
                    if (!seen.Contains(next) && !deadendsSet.Contains(next))
                    {
                        seen.Add(next);
                        queue.Enqueue(new State(next, curr.Depth + 1));
                    }
                }
            }

            return -1;
        }

        int UpdateValue(int value, int offset, Func<int, int> update)
        {
            int v = value;
            for (int i = 0; i < offset; i++)
            {
                v /= 10;
            }
            v %= 10;
            int uv = update(v);
            uv = (uv + 10) % 10;
            for (int i = 0; i < offset; i++)
            {
                v *= 10;
                uv *= 10;
            }

            int r = value;
            return r - v + uv;
        }
    }

    public class SolutionUsingStrings
    {
        class State
        {
            public string Value { get; }
            public int Depth { get; }

            public State(string value, int depth)
            {
                Value = value;
                Depth = depth;
            }
        }

        public int OpenLock(string[] deadends, string target)
        {
            var deadendsSet = new HashSet<string>(deadends);

            if (deadendsSet.Contains("0000"))
                return -1;
            if (target == "0000")
                return 0;

            var first = new State("0000", 0);

            var queue = new Queue<State>();
            queue.Enqueue(first);
            var seen = new HashSet<string>();
            seen.Add("0000");
            while (queue.Any())
            {
                State curr = queue.Dequeue();

                if (curr.Value == target)
                {
                    return curr.Depth;
                }

                for (int i = 0; i < 4; i++)
                {
                    string prev = UpdateValue(curr.Value, i, v => (char)(v - 1));
                    if (!seen.Contains(prev) && !deadendsSet.Contains(prev))
                    {
                        // Console.WriteLine($"Enqueueing {prev} {curr.Depth + 1}");
                        seen.Add(prev);
                        queue.Enqueue(new State(prev, curr.Depth + 1));
                    }

                    string next = UpdateValue(curr.Value, i, v => (char)(v + 1));
                    if (!seen.Contains(next) && !deadendsSet.Contains(next))
                    {
                        // Console.WriteLine($"Enqueueing {next} {curr.Depth + 1}");
                        seen.Add(next);
                        queue.Enqueue(new State(next, curr.Depth + 1));
                    }
                }
            }

            return -1;
        }

        string UpdateValue(string value, int offset, Func<char, char> update)
        {
            char[] v = value.ToCharArray();
            char uv = update(v[offset]);
            if (uv == '0' - 1)
                uv = '9';
            else if (uv == '9' + 1)
                uv = '0';
            v[offset] = uv;
            return new string(v);
        }
    }
}

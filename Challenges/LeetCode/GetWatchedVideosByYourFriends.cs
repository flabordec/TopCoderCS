using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.GetWatchedVideosByYourFriends
{
    public class Solution
    {
        class Node
        {
            public int Index { get; }
            public int Depth { get; }

            public Node(int index, int depth)
            {
                Index = index;
                Depth = depth;
            }
        }

        public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>();

            bool[] seen = new bool[100];
            seen[id] = true;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(new Node(id, 0));
            while (queue.Any())
            {
                Node curr = queue.Dequeue();
                if (curr.Depth == level)
                {
                    foreach (var video in watchedVideos[curr.Index])
                    {
                        if (!frequencies.ContainsKey(video))
                            frequencies.Add(video, 0);
                        frequencies[video]++;
                    }
                }
                else
                {
                    foreach (var nextFriend in friends[curr.Index])
                    {
                        if (!seen[nextFriend])
                        {
                            queue.Enqueue(new Node(nextFriend, curr.Depth + 1));
                            seen[nextFriend] = true;
                        }
                    }
                }
            }

            var ret =
                from f in frequencies
                let v = f.Key
                let freq = f.Value
                orderby freq, v
                select v;
            return ret.ToList();
        }
    }
}
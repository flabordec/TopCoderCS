using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.KeysAndRooms
{
    public class Solution
    {
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            if (rooms.Count <= 1)
                return true;

            int nVisited = 1;
            BitArray visited = new BitArray(rooms.Count);
            visited.Set(0, true);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            while (queue.Any())
            {
                int curr = queue.Dequeue();
                foreach (var key in rooms[curr])
                {
                    if (!visited.Get(key))
                    {
                        visited.Set(key, true);
                        nVisited++;
                        if (nVisited == rooms.Count)
                            return true;

                        queue.Enqueue(key);
                    }
                }
            }
            return false;
        }
    }
}

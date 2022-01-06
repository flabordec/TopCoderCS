using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.BusRoutes;

public class Solution
{
    record Node(int Group, int Depth);

    public int NumBusesToDestination(int[][] routes, int source, int target)
    {
        if (source == target)
            return 0;

        // maps bus_group to bus_groups
        Dictionary<int, HashSet<int>> busGroupsGraph = new();

        // maps bus_group to stops
        Dictionary<int, HashSet<int>> busGroupToStops = new();

        // maps stops to bus_group
        Dictionary<int, HashSet<int>> stopToBusGroups = new();



        // [[1, 2, 3], [3, 4, 5]]
        // 0 -> 1
        // 1 -> 0
        for (int i = 0; i < routes.Length; i++)
        {
            busGroupsGraph.Add(i, new());

            busGroupToStops.Add(i, new());
            for (int j = 0; j < routes[i].Length; j++)
            {
                int stop = routes[i][j];
                busGroupToStops[i].Add(stop);

                if (!stopToBusGroups.ContainsKey(stop))
                    stopToBusGroups.Add(stop, new());
                stopToBusGroups[stop].Add(i);
            }
        }

        for (int i = 0; i < routes.Length; i++)
        {
            var stops = busGroupToStops[i];
            foreach (var stop in stops)
            {
                var groupsForStop = stopToBusGroups[stop];
                foreach (var group in groupsForStop)
                {
                    busGroupsGraph[i].Add(group);
                }
            }
        }

        HashSet<int> seen = new HashSet<int>();
        HashSet<int> startingGroups = stopToBusGroups[source];
        Queue<Node> queue = new();
        foreach (var startingGroup in startingGroups)
        {
            queue.Enqueue(new Node(startingGroup, 1));
            seen.Add(startingGroup);
        }

        while (queue.Any())
        {
            Node curr = queue.Dequeue();

            var stopsForCurrGroup = busGroupToStops[curr.Group];
            if (stopsForCurrGroup.Contains(target))
                return curr.Depth;

            foreach (var nextGroup in busGroupsGraph[curr.Group])
            {
                if (!seen.Contains(nextGroup))
                {
                    queue.Enqueue(new Node(nextGroup, curr.Depth + 1));
                    seen.Add(nextGroup);
                }
            }
        }

        return -1;
    }
}
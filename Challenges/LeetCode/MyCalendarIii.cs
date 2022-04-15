using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.MyCalendarIii
{
    public class Event
    {
        public int Time { get; }
        public int NumberOfStarts { get; set; }
        public int NumberOfEnds { get; set; }

        public Event(int time, bool isStart)
        {
            Time = time;
            NumberOfStarts = isStart ? 1 : 0;
            NumberOfEnds = isStart ? 0 : 1;
        }
    }

    public class EventTimeComparer : IComparer<Event>
    {
        public int Compare(Event x, Event y) => x.Time.CompareTo(y.Time);
    }

    public class MyCalendarThree
    {
        EventTimeComparer _comparer = new EventTimeComparer();
        List<Event> _events = new List<Event>();

        public MyCalendarThree()
        {

        }

        public int Book(int start, int end)
        {
            var startE = new Event(start, true);
            int startIx = AddEvent(startE);

            var endE = new Event(end, false);
            int endIx = AddEvent(endE);

            int maxCount = 0;
            int currentCount = 0;
            for (int i = 0; i < _events.Count; i++)
            {
                currentCount -= _events[i].NumberOfEnds;
                currentCount += _events[i].NumberOfStarts;
                maxCount = Math.Max(currentCount, maxCount);
            }
            return maxCount;
        }

        private int AddEvent(Event evt)
        {
            int ix = _events.BinarySearch(evt, _comparer);
            if (ix >= 0)
            {
                _events[ix].NumberOfStarts += evt.NumberOfStarts;
                _events[ix].NumberOfEnds += evt.NumberOfEnds;
            }
            else
            {
                ix = -ix - 1;
                _events.Insert(ix, evt);
            }
            return ix;
        }
    }
}

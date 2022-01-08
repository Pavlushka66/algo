using System;
using System.Collections.Generic;
using System.Linq;
using Some.Tools;

namespace Some;

public static class MeetingRoomsII
{
    public static int Run(params (int start, int end)[] timeIntervals)
    {
        var heap = new MinHeap<TimeInterval>(timeIntervals.Select(t => new TimeInterval(t.start, t.end)));

        var maxRooms = 0;
        var inProgress = new List<TimeInterval>();
        while (heap.Count > 0)
        {
            var current = heap.Pop();
            inProgress = inProgress.Where(r => r.End >= current.Start).ToList();
            inProgress.Add(current);
            if (maxRooms < inProgress.Count)
            {
                maxRooms = inProgress.Count;
            }
        }

        return maxRooms;
    }

    private class TimeInterval: IComparable<TimeInterval>
    {
        public TimeInterval()
        {
            
        }

        public TimeInterval(int start, int end)
        {
            Start = start;
            End = end;
        }
        public int Start { get; set; }
        public int End { get; set; }

        public int CompareTo(TimeInterval other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Start.CompareTo(other.Start);
        }
    }
}
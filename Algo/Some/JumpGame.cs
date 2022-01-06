using System.Collections.Generic;

namespace Some;

public static class JumpGame
{
    public static bool Run(int[] input, int startIndex)
    {
        if (startIndex < 0 || startIndex >= input.Length)
            return false;
        var hasNoZero = true;
        for (var i = 0; i < input.Length; i++)
        {
            var current = input[i];
            if (current == 0)
            {
                hasNoZero = false;
                break;
            }
        }

        if (hasNoZero)
            return false;

        var q = new Queue<int>();
        q.Enqueue(startIndex);
        
        var checkedCells = new HashSet<int>();

        while (q.Count > 0)
        {
            var current = q.Dequeue();
            if (checkedCells.Contains(current))
                continue;
            checkedCells.Add(current);
            
            if (input[current] == 0)
                return true;
            var offset = input[current];
            if (current - offset >= 0)
                q.Enqueue(current - offset);
            if (current + offset < input.Length)
                q.Enqueue(current + offset);
        }

        return false;
    }
}
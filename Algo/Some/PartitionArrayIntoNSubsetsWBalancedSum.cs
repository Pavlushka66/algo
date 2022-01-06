using System;
using System.Collections.Generic;

namespace Some;

public static class PartitionArrayIntoNSubsetsWBalancedSum
{
    public static List<int>[] Run(int[] input, int n)
    {
        if (n == 0)
            return Array.Empty<List<int>>();
        if (n == 1)
            return new[]
            {
                new List<int>(input)
            };
        Array.Sort(input);
        var sums = new long[n];
        var result = new List<int>[n];
        for (var i = input.Length-1; i >= 0; --i)
        {
            var current = input[i];
            var addToIndex = MinMaxArrayMemeber(sums, current);
            if (result[addToIndex] == null)
                result[addToIndex] = new List<int>();

            result[addToIndex].Add(current);
            sums[addToIndex] += current;
        }

        return result;
    }

    private static int MinMaxArrayMemeber(long[] sums, int current)
    {
        if (current == 0) 
            return 0;
        var min = 0;
        var findMin = current > 0;
        for (var i = 1; i < sums.Length; i++)
        {
            if (findMin && sums[i] < sums[min] || sums[i] > sums[min])
                min = i;
        }
        
        return min;
    }
}
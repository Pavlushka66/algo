using System.Collections.Generic;

namespace Some.NumberOfIslands
{
    public static class NumberOfIslandsRunner
    {
        public static int Run(int[][] input)
        {
            if (input == null || input.Length == 0 || input[0].Length == 0)
                return 0;
            var width = input.Length;
            var height = input[0].Length;
            var result = 0;
            var visited = new HashSet<KeyValuePair<int, int>>();

            for (var row = 0; row < width; row++)
            {
                for (var col = 0; col < height; col++)
                {
                    var current = new KeyValuePair<int, int>(row, col);
                    if (!visited.Contains(current) && input[row][col] == 1)
                    {
                        result++;

                        var queue = new Queue<KeyValuePair<int, int>>();
                        queue.Enqueue(current);

                        while (queue.Count != 0)
                        {
                            var (x, y) = queue.Dequeue();
                            var right = new KeyValuePair<int,int>(x + 1, y);
                            ProcessCell(right, input, visited, queue, true);
                            var bottom = new KeyValuePair<int,int>(x, y + 1);
                            ProcessCell(bottom, input, visited, queue, true);
                            var left = new KeyValuePair<int,int>(x - 1, y);
                            ProcessCell(left, input, visited, queue, false);
                            var top = new KeyValuePair<int,int>(x, y - 1);
                            ProcessCell(top, input, visited, queue, false);
                        }
                    }
                }
            }

            return result;
        }

        private static void ProcessCell(KeyValuePair<int, int> cellToCheck, int[][] input,
            ISet<KeyValuePair<int, int>> visited, Queue<KeyValuePair<int, int>> queue, bool caNtBeVisited)
        {
            if (cellToCheck.Key >= 0 && cellToCheck.Key < input.Length &&
                cellToCheck.Value >= 0 && cellToCheck.Value < input[0].Length &&
                input[cellToCheck.Key][cellToCheck.Value] == 1 && // take value from array is faster than hash calculation
                (caNtBeVisited || !visited.Contains(cellToCheck)))
            {
                visited.Add(cellToCheck);
                queue.Enqueue(cellToCheck);
            }
        }
    }
}
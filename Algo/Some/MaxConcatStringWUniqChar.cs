using System.Collections.Generic;

namespace Some
{
    public class MaxConcatStringWUniqChar
    {
        private class ElementData
        {
            public HashSet<char> Chars { get; set; }
            public int Lenght { get; set; }
        }

        public static int Run(string[] input)
        {
            var data = new ElementData[input.Length];
            var connections = new Dictionary<int, HashSet<int>>();
            var max = 0;
            for (var i=0; i<input.Length; ++i)
            {
                connections.Add(i, new HashSet<int>());
                var currentStr = input[i];
                data[i] = new ElementData
                {
                    Lenght = currentStr.Length,
                    Chars = new HashSet<char>()
                };
                max = currentStr.Length > max ? currentStr.Length : max;
                var currentData = data[i];
                foreach (var chr in currentStr)
                {
                    currentData.Chars.Add(chr);
                    for (var p = 0; p < i; ++p)
                    {
                        var pChars = data[p].Chars;
                        if (pChars.Contains(chr))
                        {
                            connections[i].Add(p);
                            connections[p].Add(i);
                        }
                    }
                }
            }

            for (var i = 0; i < data.Length; ++i)
            {
                var currentLength = data[i].Lenght;
                var skip = connections[i];
                for (var j = 0; j < data.Length; j++)
                {
                    if (i == j || skip.Contains(j))
                        continue;
                    foreach (var skipElement in connections[j])
                    {
                        skip.Add(skipElement);
                    }

                    currentLength += data[j].Lenght;
                }

                max = currentLength > max ? currentLength : max;
            }

            return max;
        }
    }
}
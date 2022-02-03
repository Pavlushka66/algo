using System;
using System.Text;

namespace Some;

public static class RemoveKDigits
{
    public static long Run(string input, int k)
    {
        var numLen = input.Length;
        if (numLen <= k)
            return 0;

        if (k < 1)
            return long.Parse(input);

        var result = new StringBuilder("0");
        var i = 1;
        var previous = int.Parse(input[0].ToString());
        while (i < numLen)
        {
            var current = int.Parse(input[i].ToString());
            var charsLeft = numLen - (i + 1);
            
            Console.WriteLine($"current({current}) previous({previous}) k({k}) charsLeft({charsLeft}) result({result})");

            if (charsLeft == 0)
            {
                if (k == 1)
                {
                    result.Append(Math.Min(current, previous));
                }
                if (k == 0)
                {
                    result.Append(previous);
                    result.Append(current);
                }
            }
            else
            {
                if ((k == 0 || current > previous) && k <= charsLeft+1) {
                    result.Append(previous);
                }
                else
                {
                    --k;
                }
            }

            previous = current;
            ++i;
        }
        
        return long.Parse(result.ToString());
    }
}
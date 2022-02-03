using System.Collections.Generic;
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

        var st = new Stack<int>();
        for (var i = 0; i < numLen; ++i)
        {
            var current = int.Parse(input[i].ToString());
            while (k != 0 && st.Count != 0 && current < st.Peek())
            {
                st.Pop();
                --k;
            }
            st.Push(current);
        }

        for (var i = 0; i < k; i++)
        {
            st.Pop();
        }

        var sb = new StringBuilder(0);

        var resultArray = st.ToArray();
        for (var i = resultArray.Length - 1; i > -1; --i)
        {
            sb.Append(resultArray[i]);
        }
        
        return long.Parse(sb.ToString());
    }
}
using System;

namespace Some
{
    public static class ValidParenthesisString
    {
        public static bool Run(string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;

            var high = 0;
            var low = 0;

            foreach (var symbol in input)
            {
                switch (symbol)
                {
                    case '(':
                        low++;
                        high++;
                        break;
                    case ')':
                        if (high == 0) 
                            return false;
                        if (low > 0)
                            low--;
                        high--;
                        break;
                    case '*':
                        if (low > 0) 
                            low--;
                        high++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(symbol), symbol, $"unknown symbol [{symbol}]");
                }
            }

            return low == 0;
        }
    }
}
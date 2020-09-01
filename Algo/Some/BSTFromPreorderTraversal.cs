using System;
using Some.Tools;

namespace Some
{
    public static class BSTFromPreorderTraversal
    {
        public static int Run(int[] input)
        {
            if (input == null || input.Length == 0)
                throw new InvalidOperationException();
            
            var root = input[0];

            var left = new MaxHeap<int>();
            var right = new MinHeap<int>();
            
            for (var i = 1; i < input.Length; i++)
            {
                var current = input[i];
                if (current <= root)
                {
                    if (left.Count > right.Count)
                    {
                        if (left.GetRoot() > current)
                        {
                            right.Add(root);
                            root = left.Pop();
                            left.Add(current);
                        }
                        else
                        {
                            right.Add(root);
                            root = current;
                        }
                    }
                    else
                    {
                        left.Add(current);
                    }
                }
                else
                {
                    if (right.Count + 1 > left.Count)
                    {
                        if (right.GetRoot() < current)
                        {
                            left.Add(root);
                            root = right.Pop();
                            right.Add(current);
                        }
                        else
                        {
                            left.Add(root);
                            root = current;
                        }
                    }
                    else
                    {
                        right.Add(current);
                    }
                }
            }
            return root;
        }
    }
}
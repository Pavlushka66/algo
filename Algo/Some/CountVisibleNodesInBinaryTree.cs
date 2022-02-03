using System;
using System.Collections.Generic;
using Some.Tools;

namespace Some;

public static class CountVisibleNodesInBinaryTree
{
    public static int Run(BinaryTreeNode<int> root)
    {
        var s = new Stack<(BinaryTreeNode<int> node, int maxValue)>();
        s.Push((root, root.Value));
        var visibleNodesCount = 0;
        while (s.Count > 0)
        {
            var current = s.Pop();
            if (current.node.Value >= current.maxValue)
            {
                ++visibleNodesCount;
            }

            var hasLeft = current.node.Left != null;
            var hasRight = current.node.Right != null;
            if (hasLeft)
            {
                s.Push((current.node.Left, Math.Max(current.node.Left.Value, current.maxValue)));
            }
            if (hasRight)
            {
                s.Push((current.node.Right, Math.Max(current.node.Right.Value, current.maxValue)));
            }
        }

        return visibleNodesCount;
    }
}
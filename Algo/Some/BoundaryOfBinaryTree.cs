using System.Collections.Generic;
using Some.Tools;

namespace Some
{
    public static class BoundaryOfBinaryTree<T>
    {
        public static IEnumerable<T> Run(BinaryTreeNode<T> root)
        {
            if (root == null)
                yield break;
            
            var stack = new Stack<BinaryTreeNode<T>>();
            var mostRightValuesStack = new Stack<T>();

            if (root.Right != null)
                stack.Push(root.Right);
            yield return root.Value;

            var currentNode = root;
            // most left branch should be added to output
            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
                if (currentNode.Right != null)
                    stack.Push(currentNode.Right);
                yield return currentNode.Value;
            }

            // return leaves from the middle of the tree
            var hasNodesInStack = stack.Count > 0;
            while (hasNodesInStack)
            {
                currentNode = stack.Pop();
                var isCurrentRoot = stack.Count == 0;

                var hasLeft = currentNode.Left != null;
                var hasRight = currentNode.Right != null;
                
                if (hasRight)
                    stack.Push(currentNode.Right);
                
                if (hasLeft) // left should be popped from stack first
                    stack.Push(currentNode.Left);
                
                if (!hasLeft && !hasRight)
                    yield return currentNode.Value;
                else if (isCurrentRoot)
                    mostRightValuesStack.Push(currentNode.Value);

                hasNodesInStack = stack.Count > 0;
            }
            
            // return most right values
            while (mostRightValuesStack.Count > 0)
                yield return mostRightValuesStack.Pop();
        }
    }
}
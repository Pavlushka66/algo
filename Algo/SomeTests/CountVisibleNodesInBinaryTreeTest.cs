using NUnit.Framework;
using Some;
using Some.Tools;

namespace SomeTests;

[TestFixture]
public class CountVisibleNodesInBinaryTreeTest
{
    [Test]
    public void BasicScenario()
    {
        var root = new BinaryTreeNode<int>(3)
        {
            Left = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(3)
            },
            Right = new BinaryTreeNode<int>(4)
            {
                Left = new BinaryTreeNode<int>(1),
                Right = new BinaryTreeNode<int>(5)
            }
        };
        var actual = CountVisibleNodesInBinaryTree.Run(root);
        
        Assert.That(actual, Is.EqualTo(4));
    }
}
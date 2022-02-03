using System.Linq;
using NUnit.Framework;
using Some;
using Some.Tools;

namespace SomeTests
{
    public class BoundaryOfBinaryTreeTest
    {
        [Test]
        public void NullTree()
        {
            var result = BoundaryOfBinaryTree<int>.Run(null);
            Assert.IsEmpty(result);
        }

        [Test]
        public void TreeWithOneNode()
        {
            var result = BoundaryOfBinaryTree<int>.Run(new BinaryTreeNode<int>(1));
            Assert.AreEqual(new[] {1}, result);
            
            Assert.That(3/2, Is.EqualTo(1));
        }

        [Test]
        public void OnlyLeftNodesInTheTree()
        {
            var tree = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(3)
                }
            };
            var result = BoundaryOfBinaryTree<int>.Run(tree);
            Assert.AreEqual(new[] {1, 2, 3}, result);
        }

        [Test]
        public void OnlyRightNodesInTheTree()
        {
            var tree = new BinaryTreeNode<int>(1)
            {
                Right = new BinaryTreeNode<int>(3)
                {
                    Right = new BinaryTreeNode<int>(2)
                }
            };
            var result = BoundaryOfBinaryTree<int>.Run(tree);
            Assert.AreEqual(new[] {1, 2, 3}, result);
        }

        [Test]
        public void RightLeavesShouldNtReturnTwice()
        {
            var tree = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(3),
                    Right = new BinaryTreeNode<int>(4)
                }
            };
            var result = BoundaryOfBinaryTree<int>.Run(tree);
            Assert.AreEqual(new[] {1, 2, 3, 4}, result);
        }

        [Test]
        public void RightLeavesShouldNtReturnBeforeLeftNodes()
        {
            var tree = new BinaryTreeNode<int>(1)
            {
                Right = new BinaryTreeNode<int>(4)
                {
                    Left = new BinaryTreeNode<int>(2),
                    Right = new BinaryTreeNode<int>(3)
                }
            };
            var result = BoundaryOfBinaryTree<int>.Run(tree);
            Assert.AreEqual(new[] {1, 2, 3, 4}, result);
        }

        [Test]
        public void FullTree()
        {
            var tree = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(3),
                    Right = new BinaryTreeNode<int>(4)
                },
                Right = new BinaryTreeNode<int>(7)
                {
                    Left = new BinaryTreeNode<int>(5),
                    Right = new BinaryTreeNode<int>(6)
                }
            };
            var result = BoundaryOfBinaryTree<int>.Run(tree);
            Assert.AreEqual(new[] {1, 2, 3, 4, 5, 6, 7}, result);
        }

        [Test]
        public void DoNtReturnValuesFromInsideTheTree()
        {
            var tree = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(3)
                    {
                        Left = new BinaryTreeNode<int>(4),
                        Right = new BinaryTreeNode<int>(5)
                    },
                    Right = new BinaryTreeNode<int>(-1)
                    {
                        Left = new BinaryTreeNode<int>(6),
                        Right = new BinaryTreeNode<int>(7)
                    }
                },
                Right = new BinaryTreeNode<int>(13)
                {
                    Left = new BinaryTreeNode<int>(-1)
                    {
                        Left = new BinaryTreeNode<int>(8),
                        Right = new BinaryTreeNode<int>(9)
                    },
                    Right = new BinaryTreeNode<int>(12)
                    {
                        Left = new BinaryTreeNode<int>(10),
                        Right = new BinaryTreeNode<int>(11)
                    }
                }
            };
            var result = BoundaryOfBinaryTree<int>.Run(tree);
            Assert.AreEqual(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}, result);
        }
    }
}
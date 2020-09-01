using System;
using NUnit.Framework;
using Some.BSTFromPreorderTraversal;

namespace SomeTests.BSTFromPreorderTraversal
{
    public class BSTFromPreorderTraversalTest
    {
        [Test] public void InputIsNull()
        {
            int[] input = null;
            Assert.Throws<InvalidOperationException>(() => BSTFromPreorderTraversalRunner.Run(input));
        }
        
        [Test] public void InputIsEmpty()
        {
            int[] input = new int[0];
            Assert.Throws<InvalidOperationException>(() => BSTFromPreorderTraversalRunner.Run(input));
        }
        
        [Test]
        public void SingleItem()
        {
            var input = new[] { 3 };
            var root = BSTFromPreorderTraversalRunner.Run(input);
            Assert.AreEqual(3, root);
        }
        
        [Test]
        public void FirstExample()
        {
            var input = new[] { 8,5,1,7,10,12};
            var root = BSTFromPreorderTraversalRunner.Run(input);
            Assert.AreEqual(8, root);
        }
        
        [Test]
        public void SecondExample()
        {
            var input = new[] { 8,5,1,7,10,12,3,14,4,9};
            var root = BSTFromPreorderTraversalRunner.Run(input);
            Assert.AreEqual(8, root);
        }
    }
}
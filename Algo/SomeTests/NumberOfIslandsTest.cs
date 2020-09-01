using NUnit.Framework;
using Some;

namespace SomeTests
{
    public class NumberOfIslandsTest
    {
        [Test]
        public void NullInput()
        {
            int[][] input = null;
            var result = NumberOfIslands.Run(input);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ZeroSizeInput()
        {
            var input = new int[0][];
            var result = NumberOfIslands.Run(input);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Size1X0Input()
        {
            var input = new[]
            {
                new int[0]
            };
            var result = NumberOfIslands.Run(input);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ThreeIslands()
        {
            var input = new[]
            {
                new [] {1,1,0,0,0,0,0},
                new [] {1,1,0,0,0,0,0},
                new [] {0,0,1,0,0,0,0},
                new [] {0,0,0,1,1,1,1},
                new [] {0,0,0,1,1,1,1},
                new [] {0,0,0,1,1,1,1}
            };
            var result = NumberOfIslands.Run(input);
            Assert.AreEqual(3, result);
        }
        
        [Test]
        public void OneIsland()
        {
            var input = new[]
            {
                new [] {1,1,1},
                new [] {1,1,1},
                new [] {1,1,1}
            };
            var result = NumberOfIslands.Run(input);
            Assert.AreEqual(1, result);
        }
        
        [Test]
        public void OneIslandTurnRight()
        {
            var input = new[]
            {
                new [] {1,0},
                new [] {1,1}
            };
            var result = NumberOfIslands.Run(input);
            Assert.AreEqual(1, result);
        }
        
        [Test]
        public void OneIslandTurnUp()
        {
            var input = new[]
            {
                new [] {0,1},
                new [] {1,1}
            };
            var result = NumberOfIslands.Run(input);
            Assert.AreEqual(1, result);
        }
        
        [Test]
        public void OneIslandTurnLeft()
        {
            var input = new[]
            {
                new [] {1,1},
                new [] {0,1}
            };
            var result = NumberOfIslands.Run(input);
            Assert.AreEqual(1, result);
        }
        
        [Test]
        public void OneIslandTurnDown()
        {
            var input = new[]
            {
                new [] {1,1},
                new [] {1,0}
            };
            var result = NumberOfIslands.Run(input);
            Assert.AreEqual(1, result);
        }
    }
}
using NUnit.Framework;
using Some;

namespace SomeTests
{
    [TestFixture]
    public class MaxConcatStringWUniqCharTest
    {
        [Test]
        public void BasicScenario()
        {
            var input = new[] { "aaa", "bbb", "abc", "ccc"};
            var result = MaxConcatStringWUniqChar.Run(input);
            Assert.That(result, Is.EqualTo(9));
        }
        
        [Test]
        public void NoConcat()
        {
            var input = new[] { "aaa", "aaaa", "aaaaa", "aaaaaa"};
            var result = MaxConcatStringWUniqChar.Run(input);
            Assert.That(result, Is.EqualTo(6));
        }
        
        [Test]
        public void Single()
        {
            var input = new[] { "aaa"};
            var result = MaxConcatStringWUniqChar.Run(input);
            Assert.That(result, Is.EqualTo(3));
        }
        
        [Test]
        public void BasicScenario2()
        {
            var input = new[] { "aaa", "bbb", "abc", "ccc", "abddddddddd"};
            var result = MaxConcatStringWUniqChar.Run(input);
            Assert.That(result, Is.EqualTo(14));
        }
    }
}
using NUnit.Framework;
using Some.ValidParenthesisString;

namespace SomeTests.ValidParenthesisString
{
    public class ValidParenthesisStringTest
    {
        [Test]
        public void NullInput()
        {
            Assert.True(ValidParenthesisStringRunner.Run(null));
        }
        
        [Test]
        public void EmptyInput()
        {
            Assert.True(ValidParenthesisStringRunner.Run(string.Empty));
        }
        
        [Test]
        public void OneOpenOneClose()
        {
            Assert.True(ValidParenthesisStringRunner.Run("()"));
        }
        
        [Test]
        public void OneOpenOneAsteriskOneClose()
        {
            Assert.True(ValidParenthesisStringRunner.Run("(*)"));
        }
        
        [Test]
        public void OneAsteriskOneClose()
        {
            Assert.True(ValidParenthesisStringRunner.Run("*)"));
        }
        
        [Test]
        public void OneOpenOneAsterisk()
        {
            Assert.True(ValidParenthesisStringRunner.Run("(*"));
        }
        
        [Test]
        public void OneOpen()
        {
            Assert.False(ValidParenthesisStringRunner.Run("("));
        }
        
        [Test]
        public void OneClose()
        {
            Assert.False(ValidParenthesisStringRunner.Run(")"));
        }
        
        [Test]
        public void OneAsterisk()
        {
            Assert.True(ValidParenthesisStringRunner.Run("*"));
        }
        
        [Test]
        public void OneCloseOneAsterisk()
        {
            Assert.False(ValidParenthesisStringRunner.Run(")*"));
        }
        
        [Test]
        public void OpenOpenAsteriskCloseAsterisk()
        {
            Assert.True(ValidParenthesisStringRunner.Run("((*)*"));
        }
    }
}
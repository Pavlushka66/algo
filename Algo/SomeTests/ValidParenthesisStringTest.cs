using NUnit.Framework;
using Some;

namespace SomeTests
{
    public class ValidParenthesisStringTest
    {
        [Test]
        public void NullInput()
        {
            Assert.True(ValidParenthesisString.Run(null));
        }
        
        [Test]
        public void EmptyInput()
        {
            Assert.True(ValidParenthesisString.Run(string.Empty));
        }
        
        [Test]
        public void OneOpenOneClose()
        {
            Assert.True(ValidParenthesisString.Run("()"));
        }
        
        [Test]
        public void OneOpenOneAsteriskOneClose()
        {
            Assert.True(ValidParenthesisString.Run("(*)"));
        }
        
        [Test]
        public void OneAsteriskOneClose()
        {
            Assert.True(ValidParenthesisString.Run("*)"));
        }
        
        [Test]
        public void OneOpenOneAsterisk()
        {
            Assert.True(ValidParenthesisString.Run("(*"));
        }
        
        [Test]
        public void OneOpen()
        {
            Assert.False(ValidParenthesisString.Run("("));
        }
        
        [Test]
        public void OneClose()
        {
            Assert.False(ValidParenthesisString.Run(")"));
        }
        
        [Test]
        public void OneAsterisk()
        {
            Assert.True(ValidParenthesisString.Run("*"));
        }
        
        [Test]
        public void OneCloseOneAsterisk()
        {
            Assert.False(ValidParenthesisString.Run(")*"));
        }
        
        [Test]
        public void OpenOpenAsteriskCloseAsterisk()
        {
            Assert.True(ValidParenthesisString.Run("((*)*"));
        }
    }
}
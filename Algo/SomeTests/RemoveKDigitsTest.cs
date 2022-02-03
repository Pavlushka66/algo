using NUnit.Framework;
using Some;

namespace SomeTests;

[TestFixture]
public class RemoveKDigitsTest
{
    [TestCase("101", 2, 0L)]
    [TestCase("321", 2, 1L)]
    [TestCase("1", 2, 0L)]
    [TestCase("1", 1, 0L)]
    [TestCase("1", 0, 1L)]
    [TestCase("123456", 5, 1L)]
    [TestCase("11111111", 5, 111L)]
    [TestCase("11111123", 5, 111L)]
    [TestCase("10200", 1, 200L)]
    [TestCase("1432219", 3, 1219L)]
    public void Simple(string input, int k, long expected)
    {
        var actual = RemoveKDigits.Run(input, k);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
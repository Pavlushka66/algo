using System.Linq;
using NUnit.Framework;
using Some;

namespace SomeTests;

[TestFixture]
public class JumpGameTest
{
    [TestCase("0", 0, true)]
    [TestCase("0", -1, false)]
    [TestCase("0", 1, false)]
    [TestCase("1", 0, false)]
    [TestCase("3,0,2,1,3", 0, true)]
    [TestCase("2,0,2", 0, false)] // loop
    public void BasicScenario(string source, int startIndex, bool expected)
    {
        var actual = JumpGame.Run(source.Split(',').Select(int.Parse).ToArray(), startIndex);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
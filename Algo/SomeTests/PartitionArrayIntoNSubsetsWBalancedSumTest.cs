using System.Linq;
using NUnit.Framework;
using Some;

namespace SomeTests;

[TestFixture]
public class PartitionArrayIntoNSubsetsWBalancedSumTest
{
    [Test]
    public void ZeroBuckets()
    {
        var input = new [] {1,1,1};
        var result = PartitionArrayIntoNSubsetsWBalancedSum.Run(input, 0);
        
        Assert.That(result.Length, Is.EqualTo(0));
    }
    
    [Test]
    public void OneBucket()
    {
        var input = new [] {1,1,1};
        var result = PartitionArrayIntoNSubsetsWBalancedSum.Run(input, 1);
        
        var actual = result.Select(a => a?.ToArray() ?? new int[0]).ToArray();
        Assert.That(actual.Length, Is.EqualTo(1));
        Assert.That(actual[0], Is.EquivalentTo(new [] {1, 1, 1}));
    }
    
    [Test]
    public void BasicScenario()
    {
        var input = new [] {1,1,1,1,1,1,1000};
        var result = PartitionArrayIntoNSubsetsWBalancedSum.Run(input, 4);

        var actual = result.Select(a => a?.ToArray() ?? new int[0]).ToArray();
        Assert.That(actual.Length, Is.EqualTo(4));
        Assert.That(actual, Is.EquivalentTo(new [] {new [] {1000}, new [] {1,1}, new [] {1,1}, new [] {1,1}}));
    }
    
    [Test]
    public void AlmostEqual()
    {
        var input = new [] {1,1,1,1,1,1,2,1};
        var result = PartitionArrayIntoNSubsetsWBalancedSum.Run(input, 4);

        var actual = result.Select(a => a?.ToArray() ?? new int[0]).ToArray();
        Assert.That(actual.Length, Is.EqualTo(4));
        Assert.That(actual, Is.EquivalentTo(new [] {new [] {2, 1}, new [] {1,1}, new [] {1,1}, new [] {1,1}}));
    }
    
    [Test]
    public void ZeroElementStillPresentInResult()
    {
        var input = new [] {1,1,1,1,0};
        var result = PartitionArrayIntoNSubsetsWBalancedSum.Run(input, 4);

        var actual = result.Select(a => a?.ToArray() ?? new int[0]).ToArray();
        Assert.That(actual.Length, Is.EqualTo(4));
        Assert.That(actual, Is.EquivalentTo(new [] {new [] {1,0}, new [] {1}, new [] {1}, new [] {1}}));
    }
    
    [Test]
    public void NegativeElement()
    {
        var input = new [] {1,1,1,2,-1};
        var result = PartitionArrayIntoNSubsetsWBalancedSum.Run(input, 4);

        var actual = result.Select(a => a?.ToArray() ?? new int[0]).ToArray();
        Assert.That(actual.Length, Is.EqualTo(4));
        Assert.That(actual, Is.EquivalentTo(new [] {new [] {2,-1}, new [] {1}, new [] {1}, new [] {1}}));
    }
}
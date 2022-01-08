using NUnit.Framework;
using Some;

namespace SomeTests;

[TestFixture]
public class MeetingRoomsIITest
{
    [Test]
    public void BasicScenario()
    {
        var actual = MeetingRoomsII.Run((1,2),(2,6),(2,3),(3,6),(4,6),(5,6),(6,6),(6,7),(8,9));
        Assert.That(actual, Is.EqualTo(6));
    }
    
    [Test]
    public void SingleRoom()
    {
        var actual = MeetingRoomsII.Run((1,2),(3,4),(5,6),(7,8));
        Assert.That(actual, Is.EqualTo(1));
    }
    
    [Test]
    public void Empty()
    {
        var actual = MeetingRoomsII.Run();
        Assert.That(actual, Is.EqualTo(0));
    }
    
    [Test]
    public void TwoRooms()
    {
        var actual = MeetingRoomsII.Run((1,2),(2,3),(3,4),(4,5));
        Assert.That(actual, Is.EqualTo(2));
    }
}
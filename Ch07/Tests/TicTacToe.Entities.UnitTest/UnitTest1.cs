using FluentAssertions;

namespace TicTacToe.Entities.UnitTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Row.One.Value.Should().Be(0);
    }
}
using TicTacToe.Entities;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace TicTacToe.UseCases.UnitTest;

public class TicTacToeUseCaseTest
{
    private readonly ITestOutputHelper _output;

    public TicTacToeUseCaseTest(ITestOutputHelper output)
    {
        _output = output;
    }

    // 먼저 플레이를 시작하는 플레이어는 X이다.
    [Fact]
    public void Player_X_Is_The_First_To_Place_A_Marker()
    {
        // Arrange

        // Act
        TicTacToeUseCase ticTacToe = new TicTacToeUseCase();

        // Assert
        ticTacToe.WhoseTurn().Should().Be(Player.X);
    }

    // 첫 번째 플레이어는 어디에든 표시할 수 있다.
    [Fact]
    public void The_First_Player_Can_Place_Marker_Anywhere()
    {
        // Arrange

        // Act
        TicTacToeUseCase ticTacToe = new TicTacToeUseCase();

        // Assert
        ticTacToe.CanPlaceMarkerAt(Row.One, Column.One).Should().BeTrue();
        ticTacToe.CanPlaceMarkerAt(Row.One, Column.Two).Should().BeTrue();
        ticTacToe.CanPlaceMarkerAt(Row.One, Column.Three).Should().BeTrue();
        ticTacToe.CanPlaceMarkerAt(Row.Two, Column.One).Should().BeTrue();
        ticTacToe.CanPlaceMarkerAt(Row.Two, Column.Two).Should().BeTrue();
        ticTacToe.CanPlaceMarkerAt(Row.Two, Column.Three).Should().BeTrue();
        ticTacToe.CanPlaceMarkerAt(Row.Three, Column.One).Should().BeTrue();
        ticTacToe.CanPlaceMarkerAt(Row.Three, Column.Two).Should().BeTrue();
        ticTacToe.CanPlaceMarkerAt(Row.Three, Column.Three).Should().BeTrue();
    }

    // 플레이어는 이미 채워진 공간에는 표시를 할 수 없다.
    [Fact]
    public void After_A_Player_Places_A_Marker_The_Square_Is_Unavailable()
    {
        // Arrange
        TicTacToeUseCase ticTacToe = new TicTacToeUseCase();
        Row rowToPlace = Row.One;
        Column columnToPlace = Column.One;

        // Act
        ticTacToe.PlaceMarkerAt(rowToPlace, columnToPlace);

        // Assert
        ticTacToe.CanPlaceMarkerAt(rowToPlace, columnToPlace).Should().BeFalse();
    }
}
using TicTacToe.Entities;
using FluentAssertions;
using Xunit.Abstractions;

namespace TicTacToe.UseCases.UnitTest;

public class TicTacToeUseCaseTest
{
    private readonly ITestOutputHelper _output;

    public TicTacToeUseCaseTest(ITestOutputHelper output)
    {
        _output = output;
    }

    // 01-1. 먼저 플레이를 시작하는 플레이어는 X이다.
    [Fact]
    public void Player_X_Is_The_First_To_Place_A_Marker()
    {
        // Arrange

        // Act
        TicTacToeUseCase ticTacToe = new TicTacToeUseCase();

        // Assert
        ticTacToe.WhoseTurn().Should().Be(Player.X);
    }

    // 01-2. 첫 번째 플레이어는 어디에든 표시할 수 있다.
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

    // 02. 플레이어는 이미 채워진 공간에는 표시를 할 수 없다.
    [Fact]
    public void After_A_Player_Places_A_Marker_The_Square_Is_Unavailable()
    {
        // Arrange
        Row rowToPlace = Row.One;
        Column columnToPlace = Column.One;
        TicTacToeUseCase ticTacToe = new TicTacToeUseCase();

        // Act
        ticTacToe.PlaceMarkerAt(rowToPlace, columnToPlace);

        // Assert
        ticTacToe.CanPlaceMarkerAt(rowToPlace, columnToPlace).Should().BeFalse();
    }

    // 06. 이미 사용된 공간에 표시를 하려고 하면 에외가 발생한다.
    [Fact]
    public void Exception_Will_Be_Thrown_If_Player_Tries_To_Place_Marker_In_A_Taken_Square()
    {
        // Arrange
        Row rowToPlace = Row.One;
        Column columnToPlace = Column.One;
        TicTacToeUseCase ticTacToe = new TicTacToeUseCase();

        ticTacToe.PlaceMarkerAt(rowToPlace, columnToPlace);

        // Act
        Action act = () => ticTacToe.PlaceMarkerAt(rowToPlace, columnToPlace);

        // Assert
        act.Should().Throw<ApplicationException>();
    }

    // 04. 플레이어 O가 플레이어 X가 표시를 한 후에 표시할 수 있다.
    [Fact]
    public void Player_O_Will_Be_Next_To_Take_A_Turn_After_Player_X_Has_Placed_A_Marker()
    {
        // Arrange
        Row rowToPlace = Row.One;
        Column columnToPlace = Column.One;

        TicTacToeUseCase ticTacToe = new TicTacToeUseCase();
        ticTacToe.WhoseTurn().Should().Be(Player.X);

        // Act
        ticTacToe.PlaceMarkerAt(rowToPlace, columnToPlace);

        // Assert
        ticTacToe.WhoseTurn().Should().Be(Player.O);
    }

    // // 05. 플레이어는 존재하지 않는 공간에는 표시할 수 없다.
    // [Fact]
    // public void A_Player_Cannot_Place_A_Marker_In_A_Zone_That_Does_Not_Exist()
    // {
    //     // Arrange
    //     TicTacToeUseCase ticTacToe = new TicTacToeUseCase();
    //
    //     // Act : dotnet build 실패
    //     // 'int'에서 'TicTacToe.Entities.Row'(으)로 변환할 수 없습니다.
    //     bool result = ticTacToe.CanPlaceMarkerAt(100, 200);
    //
    //     // Assert
    //     result.Should().BeFalse();
    // }

    // // 05. 플레이어는 존재하지 않는 공간에는 표시할 수 없다.
    // [Fact]
    // public void A_Player_Cannot_Place_A_Marker_In_A_Zone_That_Does_Not_Exist()
    // {
    //     // Arrange
    //     TicTacToeUseCase ticTacToe = new TicTacToeUseCase();
    //
    //     // Act : dotnet test 실패
    //     // Ardalis.SmartEnum.SmartEnumNotFoundException : No Row with Value 100 found.
    //     bool result = ticTacToe.CanPlaceMarkerAt(Row.FromValue(100), Column.FromValue(200));
    //
    //     // Assert
    //     result.Should().BeFalse();
    // }
}
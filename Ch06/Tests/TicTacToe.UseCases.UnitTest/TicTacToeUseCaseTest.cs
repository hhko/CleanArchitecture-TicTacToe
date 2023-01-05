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

    // 07-1. 플레이어 X가 한 행에 세 게의 X 표시를 모두 하면 플레이어 X가 승리한다.
    [Fact]
    public void If_Player_X_Gets_Three_Xs_In_A_Row_Then_The_Game_Is_Won_By_Player_X()
    {
        // Arrange
        Row playerX_RowMove123 = Row.One;
        Column playerX_ColumnMove1 = Column.One;
        Column playerX_ColumnMove2 = Column.Two;
        Column playerX_ColumnMove3 = Column.Three;

        Row playerO_RowMove12 = Row.Two;
        Column playerO_ColumnMove1 = Column.One;
        Column playerO_ColumnMove2 = Column.Two;

        TicTacToeUseCase ticTacToe = new TicTacToeUseCase();

        // Act

        // X |   |   |
        //   |   |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerX_RowMove123, playerX_ColumnMove1);

        // X |   |   |
        // O |   |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerO_RowMove12, playerO_ColumnMove1);

        // X | X |   |
        // O |   |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerX_RowMove123, playerX_ColumnMove2);

        // X | X |   |
        // O | O |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerO_RowMove12, playerO_ColumnMove2);

        // X | X | X |
        // O | O |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerX_RowMove123, playerX_ColumnMove3);

        // Asert
        ticTacToe.Status().Should().Be(GameStatus.PlayerXWin);
    }

    // 07-2. 누군가 승리하거나 혹은 게임이 비기지 않은 이상 플레이어 X나 플레이어 O가 표수해야 할 순서인 상태가 있을 수 있다
    [Fact]
    public void The_Game_Status_Should_Be_Awaiting_Either_Player_X_Or_O_If_The_Game_Is_Not_Won_Or_Drawn()
    {
        // Arrange
        Row playerXrowToPlace = Row.One;
        Column playerXColumnToPlace = Column.One;

        // Act
        TicTacToeUseCase ticTacToe = new TicTacToeUseCase();

        // Assert
        ticTacToe.Status().Should().Be(GameStatus.AwaitingPlayerXToPlaceMarker);

        // Act
        ticTacToe.PlaceMarkerAt(playerXrowToPlace, playerXColumnToPlace);

        // Assert
        ticTacToe.Status().Should().Be(GameStatus.AwaitingPlayerOToPlaceMarker);
    }

    // 08. 플레이어 X가 한 열에 세 게의 X 표시를 모두 하면 플레이어 X가 승리한다.
    [Fact]
    public void If_Player_X_Gets_Three_Xs_In_A_Column_Then_The_Game_Is_Won_By_Player_X()
    {
        // Arrange
        Column playerX_ColumnMove123 = Column.One;
        Row playerX_RowMove1 = Row.One;
        Row playerX_RowMove2 = Row.Two;
        Row playerX_RowMove3 = Row.Three;

        Column playerO_ColumnMove12 = Column.Two;
        Row playerO_ColumnMove1 = Row.One;
        Row playerO_ColumnMove2 = Row.Two;

        TicTacToeUseCase ticTacToe = new TicTacToeUseCase();

        // Act

        // X |   |   |
        //   |   |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerX_RowMove1, playerX_ColumnMove123);

        // X | O |   |
        //   |   |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerO_ColumnMove1, playerO_ColumnMove12);

        // X | O |   |
        // X |   |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerX_RowMove2, playerX_ColumnMove123);

        // X | O |   |
        // X | O |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerO_ColumnMove2, playerO_ColumnMove12);

        // X | O |   |
        // X | O |   |
        // X |   |   |
        ticTacToe.PlaceMarkerAt(playerX_RowMove3, playerX_ColumnMove123);

        // Asert
        ticTacToe.Status().Should().Be(GameStatus.PlayerXWin);
    }

    // 09. 플레이어 X가 대각선으로 세 개의 X 표시를 모두 하면 플레이어 X가 승리한다.
    [Fact]
    public void If_Player_X_Gets_Three_Xs_In_A_Diagonal_Then_The_Game_Is_Won_By_Player_X()
    {
        // Arrange
        Row playerX_RowMove1 = Row.One;
        Row playerX_RowMove2 = Row.Two;
        Row playerX_RowMove3 = Row.Three;
        Column playerX_ColumnMove1 = Column.One;
        Column playerX_ColumnMove2 = Column.Two;
        Column playerX_ColumnMove3 = Column.Three;

        Row playerO_RowMove12 = Row.One;
        Column playerO_ColumnMove1 = Column.Two;
        Column playerO_ColumnMove2 = Column.Three;

        TicTacToeUseCase ticTacToe = new TicTacToeUseCase();

        // Act

        // X |   |   |
        //   |   |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerX_RowMove1, playerX_ColumnMove1);

        // X | O |   |
        //   |   |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerO_RowMove12, playerO_ColumnMove1);

        // X | O |   |
        //   | X |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerX_RowMove2, playerX_ColumnMove2);

        // X | O | O |
        //   | X |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerO_RowMove12, playerO_ColumnMove2);

        // X | O | O |
        //   | X |   |
        //   |   |   |
        ticTacToe.PlaceMarkerAt(playerX_RowMove3, playerX_ColumnMove3);

        // Asert
        ticTacToe.Status().Should().Be(GameStatus.PlayerXWin);
    }
}
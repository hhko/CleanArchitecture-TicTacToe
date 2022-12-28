using TicTacToe.Entities;
using FluentAssertions;

namespace TicTacToe.UseCases.UnitTest;

public class TicTacToeUseCaseTest
{
    [Fact]
    public void Player_X_Is_The_First_To_Place_A_Marker()
    {
        TicTacToeUseCase ticTacToe = new TicTacToeUseCase();

        ticTacToe.WhoseTurn().Should().Be(Player.X);
    }
}
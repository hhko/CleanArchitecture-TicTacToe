using TicTacToe.Entities;

namespace TicTacToe.UseCases;

public class TicTacToeUseCase
{
    public Player WhoseTurn()
    {
        return Player.X;
    }
}

using TicTacToe.Entities;

namespace TicTacToe.UseCases;

public class TicTacToeUseCase
{
    private int[,] _board = new int[3, 3];

    public Player WhoseTurn()
    {
        return Player.X;
    }

    public bool CanPlaceMarkerAt(Row row, Column column)
    {
        return _board[row, column] == 0;
    }

    public void PlaceMarkerAt(Row row, Column column)
    {
        _board[row, column] = WhoseTurn();
    }
}

using TicTacToe.Entities;

namespace TicTacToe.UseCases;

public class TicTacToeUseCase
{
    private int[,] _board = new int[3, 3];
    private Player _currentPlayer;

    public TicTacToeUseCase()
    {
        _currentPlayer = Player.X;
    }

    public Player WhoseTurn()
    {
        return _currentPlayer;
    }

    public bool CanPlaceMarkerAt(Row row, Column column)
    {
        return _board[row, column] == 0;
    }

    public void PlaceMarkerAt(Row row, Column column)
    {
        if (CanPlaceMarkerAt(row, column))
        {
            _board[row, column] = WhoseTurn();
            ChangeCurrentPlayer();
        }
        else
        {
            throw new ApplicationException(
                $"Square Row: {row}, Column: {column} already occupied by {Player.FromValue(_board[row, column])}");
        }
    }

    private void ChangeCurrentPlayer()
    {
        if (_currentPlayer == Player.X)
        {
            _currentPlayer = Player.O;
        }
        else
        {
            _currentPlayer = Player.X;
        }
    }
}

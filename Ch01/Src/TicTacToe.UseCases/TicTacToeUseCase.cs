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

    public GameStatus Status()
    {
        if (IsAWinner(Player.X))
            return GameStatus.PlayerXWin;
        else if (IsAWinner(Player.O))
            return GameStatus.PlayerOWin;
        else if (WhoseTurn() == Player.X)
            return GameStatus.AwaitingPlayerXToPlaceMarker;
        else if (WhoseTurn() == Player.O)
            return GameStatus.AwaitingPlayerOToPlaceMarker;
        else
            return GameStatus.GameDrawn;
    }

    private bool IsAWinner(Player player)
    {
        bool winner = false;

        for (int row = Row.One; row <= Row.Three; row++)
        {
            if (_board[row, Column.One] == player
                && _board[row, Column.Two] == player
                && _board[row, Column.Three] == player)
            {
                winner = true;
                break;
            }
        }

        return winner;
    }
}

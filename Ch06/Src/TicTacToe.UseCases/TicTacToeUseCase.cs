using System.Numerics;
using System.Reflection;
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

        if (IsThreeInARowWiner(player)
            || IsThreeInAColumnWiner(player)
            || IsThreeInADiagonalWiner(player))
        {
            winner = true;
        }

        return winner;
    }

    private bool IsThreeInARowWiner(Player player)
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

    private bool IsThreeInAColumnWiner(Player player)
    {
        bool winner = false;

        for (int column = Column.One; column <= Column.Three; column++)
        {
            if (_board[Row.One, column] == player
                && _board[Row.Two, column] == player
                && _board[Row.Three, column] == player)
            {
                winner = true;
                break;
            }
        }

        return winner;
    }

    private bool IsThreeInADiagonalWiner(Player player)
    {
        bool winner = false;

        if (_board[Row.One, Column.One] == player
            && _board[Row.Two, Column.Two] == player
            && _board[Row.Three, Column.Three] == player)
        {
            winner = true;
        }

        if (_board[Row.One, Column.Three] == player
            && _board[Row.Two, Column.Two] == player
            && _board[Row.Three, Column.One] == player)
        {
            winner = true;
        }

        return winner;
    }
}

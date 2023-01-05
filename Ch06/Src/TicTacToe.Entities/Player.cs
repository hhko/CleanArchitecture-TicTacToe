namespace TicTacToe.Entities;

using Ardalis.SmartEnum;

public sealed class Player : SmartEnum<Player>
{
    public static readonly Player X = new Player(nameof(X), 1);
    public static readonly Player O = new Player(nameof(O), 2);

    private Player(string name, int value) : base(name, value)
    {
    }
}
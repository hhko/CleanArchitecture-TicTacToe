namespace TicTacToe.Entities;

using Ardalis.SmartEnum;

public sealed class GameStatus : SmartEnum<GameStatus>
{
    public static readonly GameStatus PlayerXWin = new GameStatus(nameof(PlayerXWin), 1);
    public static readonly GameStatus PlayerOWin = new GameStatus(nameof(PlayerOWin), 2);
    public static readonly GameStatus GameDrawn = new GameStatus(nameof(GameDrawn), 3);
    public static readonly GameStatus AwaitingPlayerXToPlaceMarker = new GameStatus(nameof(AwaitingPlayerXToPlaceMarker), 4);
    public static readonly GameStatus AwaitingPlayerOToPlaceMarker = new GameStatus(nameof(AwaitingPlayerOToPlaceMarker), 5);

    private GameStatus(string name, int value) : base(name, value)
    {
    }
}
namespace TicTacToe.Entities;

using Ardalis.SmartEnum;

public sealed class Row : SmartEnum<Row>
{
    public static readonly Row One = new Row(nameof(One), 0);
    public static readonly Row Two = new Row(nameof(Two), 1);
    public static readonly Row Three = new Row(nameof(Three), 2);

    private Row(string name, int value) : base(name, value)
    {
    }
}
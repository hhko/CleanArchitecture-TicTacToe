namespace TicTacToe.Entities;

using Ardalis.SmartEnum;

public sealed class Column : SmartEnum<Column>
{
    public static readonly Column One = new Column(nameof(One), 0);
    public static readonly Column Two = new Column(nameof(Two), 1);
    public static readonly Column Three = new Column(nameof(Three), 2);

    private Column(string name, int value) : base(name, value)
    {
    }
}
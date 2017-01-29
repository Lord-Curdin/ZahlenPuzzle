namespace ch.bbbaden.m426.Zahlenpuzzle
{
  public class Location
  {
    public Location(int row, int column)
    {
      Row = row;
      Column = column;
    }

    public int Row { get; }

    public int Column { get; }
  }
}
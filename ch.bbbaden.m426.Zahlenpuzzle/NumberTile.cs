namespace ch.bbbaden.m426.Zahlenpuzzle
{
  public class NumberTile : ITile
  {
    public NumberTile(int number)
    {
      Number = number;
    }

    public int Number { get; }
  }
}
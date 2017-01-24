namespace ch.bbbaden.m426.Zahlenpuzzle
{
  public class Tiles
  {
    private int xSize;
    private int ySize;

    public Tiles(int xSize, int ySize)
    {
      this.xSize = xSize;
      this.ySize = ySize;
    }

    public ITile this[Location location] => null;
  }
}
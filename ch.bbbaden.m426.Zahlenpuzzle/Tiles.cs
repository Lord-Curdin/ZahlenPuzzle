using System.Collections;
using System.Collections.Generic;

namespace ch.bbbaden.m426.Zahlenpuzzle
{
  public class Tiles : IEnumerable<ITile>
  {
    private int xSize;
    private int ySize;

    public Tiles(int xSize, int ySize)
    {
      this.xSize = xSize;
      this.ySize = ySize;
    }

    public void MoveTile(Location oldLocation, Location newLocation)
    {
      throw new System.NotImplementedException();
    }

    public ITile this[Location location] => null;
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<ITile> GetEnumerator()
    {
      throw new System.NotImplementedException();
    }
  }
}
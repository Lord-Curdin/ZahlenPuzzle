using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ch.bbbaden.m426.Zahlenpuzzle
{
  internal class Tiles : IEnumerable<ITile>
  {
    // rows are the first dimension, columns the second.
    private readonly List<List<ITile>> tiles;

    public Tiles(IEnumerable<IEnumerable<ITile>> tiles)
    {
      this.tiles = tiles.Select(t => t.ToList()).ToList();
    }

    public void MoveTile(Location oldLocation, Location newLocation)
    {
      throw new System.NotImplementedException();
    }

    public bool HasLocation(Location location)
    {
      return tiles.Count <= location.Row && tiles.All(column => column.Count <= location.Column);
    }

    public ITile this[Location location] => null;

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<ITile> GetEnumerator()
    {
      return tiles.SelectMany(rows => rows).GetEnumerator();
    }
  }
}
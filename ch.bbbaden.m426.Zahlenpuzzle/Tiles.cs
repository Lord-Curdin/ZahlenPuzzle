using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ch.bbbaden.m426.Zahlenpuzzle
{
  public class Tiles : IEnumerable<ITile>
  {
    // rows are the first dimension, columns the second.
    private readonly List<List<ITile>> tiles;

    internal Tiles(IEnumerable<IEnumerable<ITile>> tiles)
    {
      this.tiles = tiles.Select(t => t.ToList()).ToList();
    }

    internal void MoveTile(Location oldLocation, Location newLocation)
    {
      ITile temp = this[newLocation];
      this[newLocation] = this[oldLocation];
      this[oldLocation] = temp;
    }

    public bool HasLocation(Location location)
    {
      return location.Row <= RowCount && location.Column <= ColumnCount;
    }

    public ITile this[Location location]
    {
      get { return tiles[location.Row][location.Column]; }
      private set { tiles[location.Row][location.Column] = value; } 
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<ITile> GetEnumerator()
    {
      return tiles.SelectMany(rows => rows).GetEnumerator();
    }

    public int RowCount => tiles.Count;
    public int ColumnCount => tiles.First().Count;
  }
}
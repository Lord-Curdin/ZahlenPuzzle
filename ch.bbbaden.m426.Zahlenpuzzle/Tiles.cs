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
      ITile temp = this[newLocation];
      this[newLocation] = this[oldLocation];
      this[oldLocation] = temp;
    }

    public bool HasLocation(Location location)
    {
      return tiles.Count <= location.Row && tiles.All(column => column.Count <= location.Column);
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

    internal int RowCount => tiles.Count;
    public int ColumnCount => tiles.First().Count;
  }
}
using System;
using System.Linq;

namespace ch.bbbaden.m426.Zahlenpuzzle
{
  public class Game
  {
    internal Tiles tiles;

    internal Game(GameTypes gameType)
    {
      tiles = TilesFactory.Get(gameType);
    }

    public event EventHandler GameFinishedEvent;

    public bool TryMoveTile(Location oldLocation, Location newLocation)
    {
      int xDistance = Math.Abs(oldLocation.Row - newLocation.Row);
      int yDistance = Math.Abs(oldLocation.Column - newLocation.Column);
      if (!(xDistance == 1 || xDistance == 0) 
        || !(yDistance == 1 || yDistance == 0) 
        || (xDistance == 1 && yDistance == 1) 
        || !tiles.HasLocation(newLocation))
      {
        return false;
      }

      tiles.MoveTile(oldLocation, newLocation);

      if (IsFinished())
      {
        RaiseGameFinishedEvent();
      }

      return true;
    }

    public Location LocationOfNumber(int number)
    {
      int rows = tiles.RowCount;
      int itemIndex = tiles.ToList().FindIndex(tile => (tile as NumberTile)?.Number == number);
      int column = itemIndex % rows;
      int columnCount = tiles.ColumnCount;
      int row = (itemIndex - column) / columnCount;

      return new Location(row, column);
    }

    public Location LocationOfEmpty()
    {
      int emptyIndex = tiles.ToList().FindIndex(tile => tile is EmptyTile);
      int rows = tiles.RowCount;
      int column = emptyIndex % rows;
      int columnCount = tiles.ColumnCount;
      int row = (emptyIndex - column) / columnCount;

      return new Location(row, column);
    }

    public Tiles Tiles => tiles;

    public void Restart(GameTypes gameType)
    {
      tiles = TilesFactory.Get(gameType);
    }

    protected virtual void RaiseGameFinishedEvent()
    {
      GameFinishedEvent?.Invoke(this, EventArgs.Empty);
    }

    protected bool IsFinished() => tiles.Last() is EmptyTile && tiles.Take(tiles.Count() - 1)
                                     .Select(tile => ((NumberTile)tile).Number)
                                     .SequenceEqual(Enumerable.Range(1, tiles.Count() - 1))
                                   && tiles.Last() is EmptyTile;
  }
}

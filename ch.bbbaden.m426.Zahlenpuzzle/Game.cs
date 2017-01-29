using System;
using System.Collections.Generic;
using System.Linq;
using ch.bbbaden.m426.Zahlenpuzzle.Linq;

namespace ch.bbbaden.m426.Zahlenpuzzle
{
  public class Game
  {
    internal Tiles tiles;

    internal Game(GameTypes gameType)
    {
      tiles = TilesFactory.Get(gameType);
    }

    public bool TryMoveTile(Location oldLocation, Location newLocation)
    {
      int xDistance = Math.Abs(oldLocation.Row - newLocation.Row);
      int yDistance = Math.Abs(oldLocation.Column - newLocation.Column);
      if (!(xDistance == 1 || xDistance == 0) || !(yDistance == 1 || yDistance == 0) || !tiles.HasLocation(newLocation))
      {
        return false;
      }

      tiles.MoveTile(oldLocation, newLocation);
      return true;
    }

    public void Restart(GameTypes gameType)
    {
      tiles = TilesFactory.Get(gameType);
    }
  }
}

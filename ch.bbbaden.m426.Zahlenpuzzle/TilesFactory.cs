using System;
using System.Collections.Generic;
using System.Linq;
using ch.bbbaden.m426.Zahlenpuzzle.Linq;

namespace ch.bbbaden.m426.Zahlenpuzzle
{
  internal static class TilesFactory
  {
    public static Tiles Get(GameTypes gameType)
    {
      switch (gameType)
      {
        case GameTypes.Easy:
          var items = new List<ITile>();
          for (int i = 0; i < 15; i++)
          {
            items.Add(new NumberTile(i));
          }

          items.Add(new EmptyTile());
          ITile temp = items[16];
          items[16] = items[15];
          items[15] = temp;

          var groupedTiles = items.GroupBy(4);
          return new Tiles(groupedTiles.Select(tiles => tiles.ToList().AsEnumerable()).ToList().AsEnumerable());
        case GameTypes.Hard:
          throw new NotImplementedException();
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(gameType), gameType, null);
      }

    }
  }
}
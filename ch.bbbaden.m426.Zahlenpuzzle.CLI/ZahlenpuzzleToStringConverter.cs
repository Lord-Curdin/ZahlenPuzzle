using System.Collections.Generic;
using System.Linq;

namespace ch.bbbaden.m426.Zahlenpuzzle.CLI
{
  public static class ZahlenpuzzleToStringConverter
  {
    public static IEnumerable<string> ToCliRepresentation(this Game game)
    {
      yield return new string('-', game.Tiles.Count());

      for (int i = 0; i < game.Tiles.Count() / game.Tiles.RowCount; i++)
      {
        string row = "| ";

        for (int j = 0; j < game.Tiles.ColumnCount; j++)
        {
          ITile tile = game.Tiles[new Location(i, j)];

          var numberTile = tile as NumberTile;
          if (numberTile != null)
          {
            row += numberTile.Number.ToString("##") +" | ";
          }
          else
          {
            row += "  " + " | ";
          }
        }

        yield return row;
        yield return new string('-', game.Tiles.Count());
      }
    }
  }
}
using System.Collections.Generic;
using System.Linq;

namespace ch.bbbaden.m426.Zahlenpuzzle.CLI
{
  public static class ZahlenpuzzleToStringConverter
  {

    public static IEnumerable<string> ToCliRepresentation(this Game game)
    {
      string line = new string('-', 5 * game.Tiles.RowCount + 1);

      yield return line;

      for (int i = 0; i < game.Tiles.Count() / game.Tiles.RowCount; i++)
      {
        string row = "| ";

        for (int j = 0; j < game.Tiles.ColumnCount; j++)
        {
          ITile tile = game.Tiles[new Location(i, j)];

          var numberTile = tile as NumberTile;
          if (numberTile != null)
          {
            row += ((numberTile.Number > 9) ? "" : " ") + numberTile.Number.ToString("#")  + " | ";
          }
          else
          {
            row += "  " + " | ";
          }
        }

        yield return row;
        yield return line;
      }
    }
  }
}
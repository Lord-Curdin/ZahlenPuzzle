using System;

namespace ch.bbbaden.m426.Zahlenpuzzle
{

  public class TileFactory
  {
    public static ITile Get(int number) => new NumberTile(number);

    public static ITile GetEmpty() => new EmptyTile();
  }
}
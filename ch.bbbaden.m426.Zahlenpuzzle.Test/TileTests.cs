using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ch.bbbaden.m426.Zahlenpuzzle.Test
{
  [TestClass]
  public class TileTests
  {
    [TestMethod]
    public void TestTileCreation()
    {
      // Arrange
      ITile tile;
      ITile emptyTile;

      // Act
      tile = TileFactory.Get(number: 2);
      emptyTile = TileFactory.GetEmpty();
      int expectedNumber = 2;

      // Assert
      Assert.IsTrue(emptyTile is EmptyTile);
      Assert.AreEqual(expectedNumber, ((NumberTile)tile).Number);
    }

    [TestMethod]
    public void TestTilesIndexer()
    {
      // Arrange
      Tiles tiles;

      // Act
      tiles = TilesFactory.Get(GameTypes.Easy);
      Action action = () => { var tile = tiles[new Location(4, 1)]; };

      // Assert
      Assert.ThrowsException<ArgumentOutOfRangeException>(action);
      Assert.IsNotNull(tiles[new Location(3, 1)]);
    }

    [TestMethod]
    public void TestMoveTiles()
    {
      // Arrange
      Tiles tiles;

      // Act
      tiles = TilesFactory.Get(GameTypes.Easy);
      Action validAction = () => { tiles.MoveTile(new Location(3, 2), new Location(3, 3)); };
      // this action is not checked by the game, but is possible in the context of tiles.
      Action uncheckedInvalidGameAction = () => { tiles.MoveTile(new Location(1, 1), new Location(3, 3)); };
      Action errorAction2 = () => { tiles.MoveTile(new Location(3, 2), new Location(4, 2)); };

      // Assert
      validAction();
      uncheckedInvalidGameAction();
      Assert.ThrowsException<ArgumentOutOfRangeException>(errorAction2);
    }


  }
}
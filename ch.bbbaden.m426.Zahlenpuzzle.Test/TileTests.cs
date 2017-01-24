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
      tiles = new Tiles(4, 4);
      Action errorFunc = () => { var tile = tiles[new Location(4, 1)]; };

      // Assert
      Assert.ThrowsException<ArgumentOutOfRangeException>(errorFunc);
      Assert.IsNotNull(tiles[new Location(3, 1)]);
    }
  }
}
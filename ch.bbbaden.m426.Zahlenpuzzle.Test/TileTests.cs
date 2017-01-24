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

      // Act

      // Assert
    }
  }
}
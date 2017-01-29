using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ch.bbbaden.m426.Zahlenpuzzle.Test
{
  [TestClass]
  public class GameTest
  {
    [TestMethod]
    public void TestRestart()
    {
      // Arrange
      Game game;
      
      // Act
      game = GameFactory.Get4On4Game();
      bool canMove = game.TryMoveTile(new Location(2, 3), new Location(3, 3));

      // Assert
      Assert.IsTrue(canMove);
      Assert.AreEqual(3, game.TileAt(x: 3, y: 3));
      game.Restart();
      Assert.AreEqual(3, game.TileAt(x: 2, y: 3));
    }
  }
}

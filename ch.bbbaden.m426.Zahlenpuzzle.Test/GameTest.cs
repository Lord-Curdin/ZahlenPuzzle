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
      bool canMove = game.TryMoveTile(new Location(2, 2), new Location(3, 2));

      // Assert
      Assert.IsTrue(canMove);
      Assert.AreEqual(11, ((NumberTile)game.tiles[new Location(3, 2)]).Number);
      game.Restart(GameTypes.Easy);
      Assert.AreEqual(11, ((NumberTile)game.tiles[new Location(2, 2)]).Number);
    }
  }
}

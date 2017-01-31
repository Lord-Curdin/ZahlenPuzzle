namespace ch.bbbaden.m426.Zahlenpuzzle
{
  public class GameFactory
  {
    public static Game Get4On4Game(GameTypes gameType = GameTypes.Easy)
    {
      return new Game(gameType);
    }
  }
}

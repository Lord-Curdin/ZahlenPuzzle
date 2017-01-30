using static System.Console;

namespace ch.bbbaden.m426.Zahlenpuzzle.CLI
{
  internal class Program
  {
    private static bool finished;

    private static void Main(string[] args)
    {
      WriteLine("Start Zahlenpuzzle");

      Game game = GameFactory.Get4On4Game(GameTypes.Easy);
      game.GameFinishedEvent += (sender, eventArgs) => finished = true;

      while (!finished)
      {
        WriteLine("Select your move!");

        bool validMove = false;

        while (!validMove)
        {
          game.ToCliRepresentation().ForEach(WriteLine);
          WriteLine("Enter the tile to move: ");
          string userMoveEntry = ReadLine();

          int move;
          if (int.TryParse(userMoveEntry, out move) && game.TryMoveTile(game.LocationOfNumber(move), game.LocationOfEmpty()))
          {
            validMove = true;
            WriteLine("Succesfully moved the tile!");
          }
          else
          {
            WriteLine("Invalid move or input! Try again.");
          }
        }

      }

      WriteLine("Game finished.");
      ReadLine();
    }
  }
}
using System;
using System.Linq;
using static System.Console;

namespace ch.bbbaden.m426.Zahlenpuzzle.CLI
{
  internal class Program
  {
    private static bool finished;

    private static void Main(string[] args)
    {
      WriteLine(new string('-', 10));
      WriteLine("Start Zahlenpuzzle");
      WriteLine(new string('-', 10));

      Game game = GameFactory.Get4On4Game(GameTypes.Easy);
      game.GameFinishedEvent += (sender, eventArgs) => finished = true;

      while (!finished)
      {
        WriteLine("Select your move!");

        bool validMove = false;

        while (!validMove)
        {
          game.ToCliRepresentation().ToList().ForEach(WriteLine);
          WriteLine("Enter the tile to move: ");
          string userMoveEntry = ReadLine();

          if (userMoveEntry == "RNG")
          {
            WriteLine("I accept you as my only RNGeezuz master.");
            Read();
          }

          int move;
          if (int.TryParse(userMoveEntry, out move) && game.TryMoveTile(game.LocationOfNumber(move), game.LocationOfEmpty()))
          {
            validMove = true;
            Clear();
            WriteLine(new string('-', 10));
            WriteLine("Succesfully moved the tile!");
            WriteLine(new string('-', 10));
          }
          else
          {
            Clear();
            WriteLine(new string('-', 10));
            WriteLine("Select your move!");
            WriteLine(new string('-', 10));
            WriteLine("Invalid move or input! Try again.");
          }
        }

      }

      WriteLine("Game finished. Congratulations!");
      game.ToCliRepresentation().ToList().ForEach(WriteLine);
      WriteLine("Want to start again (y/n)?");
      if ("y".Equals(ReadLine(), StringComparison.CurrentCultureIgnoreCase))
      {
        // ReSharper disable once TailRecursiveCall
        finished = false;
        Clear();
        Main(null);
      }
    }
  }
}
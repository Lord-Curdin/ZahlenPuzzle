using PropertyChanged;

namespace ch.bbbaden.m426.Zahlenpuzzle.GUI.ViewModels
{
  [ImplementPropertyChanged]
  public class MainWindowViewModel
  {
    private readonly Game game;

    public MainWindowViewModel(Game game)
    {
      this.game = game;
    }


  }
}
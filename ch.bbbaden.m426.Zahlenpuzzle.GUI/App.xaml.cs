using System.Windows;
using ch.bbbaden.m426.Zahlenpuzzle.GUI.ViewModels;
using PropertyChanged;

namespace ch.bbbaden.m426.Zahlenpuzzle.GUI
{
  [DoNotNotify]
  public partial class App : Application
  {
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
      var window = new Views.MainWindow { DataContext = new MainWindowViewModel() };
      window.Show();
    }
  }
}

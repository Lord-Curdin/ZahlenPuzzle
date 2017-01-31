using System.Windows;

using ch.bbbaden.m426.Zahlenpuzzle.GUI.ViewModels;

namespace ch.bbbaden.m426.Zahlenpuzzle.GUI
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
      var window = new MainWindow { DataContext = new MainWindowViewModel() };
      window.Show();
    }
  }
}

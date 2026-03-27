using System.Windows;

namespace FlaUI.WpfCalculator;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var window = new MainWindow(string.Join(" ", e.Args));
        window.Show();
    }
}

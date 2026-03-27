using CalculatorComparison.Specs.Apps;
using Reqnroll.Amp;

namespace CalculatorComparison.Specs.Services;

public class WpfCalculatorService(WpfCalculatorMainWindow mainWindow, FlaUIDriver<Profile.Wpf> driver)
{
    public WpfCalculatorMainWindow MainWindow { get; } = mainWindow;

    public void SelectWpfCalculator()
    {
        driver.SelectProfile("WPF Calculator");
    }
}

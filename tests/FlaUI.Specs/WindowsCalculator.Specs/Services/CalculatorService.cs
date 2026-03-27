using Reqnroll.Amp;
using WindowsCalculator.Specs.App;

namespace WindowsCalculator.Specs.Services;

public class CalculatorService(CalculatorMainWindow mainWindow, FlaUIDriver driver)
{
    public CalculatorMainWindow MainWindow { get; } = mainWindow;

    public void SelectWindowsCalculator()
    {
        driver.SelectProfile("Windows Calculator");
    }
}

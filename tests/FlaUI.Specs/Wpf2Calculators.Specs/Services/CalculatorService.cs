using Reqnroll.Amp;
using Wpf2Calculators.Specs.App;

namespace Wpf2Calculators.Specs.Services;

public interface ICalculatorService<N>
{
    void SwitchProfile();

    CalculatorMainWindow<N> MainWindow { get; }
}

public class CalculatorServiceOne(CalculatorMainWindow<Profile.One> mainWindow, FlaUIDriver<Profile.One> driver) : ICalculatorService<Profile.One>
{
    public CalculatorMainWindow<Profile.One> MainWindow { get; } = mainWindow;

    public void SwitchProfile()
    {
        driver.SelectProfile("Calculator One");
    }
}

public class CalculatorServiceTwo(CalculatorMainWindow<Profile.Two> mainWindow, FlaUIDriver<Profile.Two> driver) : ICalculatorService<Profile.Two>
{
    public CalculatorMainWindow<Profile.Two> MainWindow { get; } = mainWindow;

    public void SwitchProfile()
    {
        driver.SelectProfile("Calculator Two");
    }
}

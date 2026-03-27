using WpfCalculator.Specs.App;

namespace WpfCalculator.Specs.Services;

public interface ICalculatorService
{
    CalculatorMainWindow MainWindow { get; }
}

public class CalculatorService(CalculatorMainWindow mainWindow) : ICalculatorService
{
    public CalculatorMainWindow MainWindow { get; } = mainWindow;
}

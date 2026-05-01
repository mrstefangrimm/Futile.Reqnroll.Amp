using WebCalculator.Specs.App;

namespace WebCalculator.Specs.Services;

public interface ICalculatorService
{
    HomePage HomePage { get; }
}

public class CalculatorService(HomePage homePage) : ICalculatorService
{
    public HomePage HomePage { get; } = homePage;
}

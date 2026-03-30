using WebCalculator.Specs.App;

namespace WebCalculator.Specs.Services;

public interface ICalculatorService
{
    HomePage MainPage { get; }
}

public class CalculatorService(HomePage homePage) : ICalculatorService
{
    public HomePage MainPage { get; } = homePage;
}

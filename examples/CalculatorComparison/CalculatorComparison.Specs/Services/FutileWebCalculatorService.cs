using CalculatorComparison.Specs.Apps;
using Reqnroll.Amp;

namespace CalculatorComparison.Specs.Services;

public class FutileWebCalculatorService(FutileWebCalculatorHomePage homePage, PlayWrightDriver<Profile.Futile> driver)
{
    public FutileWebCalculatorHomePage MainPage { get; } = homePage;

    public void SelectFutileCalculator()
    {
        driver.SelectProfile("Futile-Calculator");
    }
}

using CalculatorComparison.Specs.Apps;
using Reqnroll.Amp;

namespace CalculatorComparison.Specs.Services;

public class WebCalculatorService(WebCalculatorHomePage homePage, PlayWrightDriver<Profile.Web> driver)
{
    public WebCalculatorHomePage MainPage { get; } = homePage;

    public void SelectWebCalculator()
    {
        driver.SelectProfile("WebCalculator");
    }
}

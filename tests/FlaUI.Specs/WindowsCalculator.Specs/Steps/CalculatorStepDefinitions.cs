using FluentAssertions;
using Reqnroll;
using WindowsCalculator.Specs.Services;

namespace WindowsCalculator.Specs.Steps;

[Binding]
internal sealed class CalculatorStepDefinitions(CalculatorService service)
{
    [Given(@"the number {string} is entered")]
    public async Task GivenTheNumberIsEntered(string number)
    {
        foreach (char ch in number)
        {
            service.MainWindow.EnterNumber(ch);
        }
    }

    [Given(@"Plus is pressed")]
    public async Task GivenPlusIsPressed()
    {
        service.MainWindow.ClickAdd();
    }

    [When(@"Equal is pressed")]
    public async Task WhenEqualIsPressed()
    {
        service.MainWindow.ClickEqual();
    }

    [Then(@"the result is {int}")]
    public async Task ThenTheResultIs(int result)
    {
        double actualResult = double.Parse(service.MainWindow.GetResult());

        result.Should().Be((int)actualResult);
    }
}

using CalculatorComparison.Specs.Services;
using FluentAssertions;
using Reqnroll;

namespace CalculatorComparison.Specs.Steps;

[Binding]
internal sealed class NumFieldCalculatorStepDefinitions(NumFieldCalculatorService service)
{
    [Given(@"the Windows calculator")]
    public void GivenTheWindowsCalculator()
    {
        service.SelectStoreAppCalculator();
    }

    [Given("the web calculator")]
    public void GivenTheWebCalculator()
    {
        service.SelectWebCalculator();
    }

    [Given(@"the number {string} is entered")]
    public async Task GivenTheNumberIsEntered(string number)
    {
        foreach (char ch in number)
        {
            await service.EnterNumber(ch);
        }
    }

    [Given(@"Plus is pressed")]
    public async Task GivenPlusIsPressed()
    {
        await service.ClickAdd();
    }

    [When(@"Equal is pressed")]
    public async Task WhenEqualIsPressed()
    {
        await service.ClickEqual();
    }

    [Then(@"the result is {int}")]
    public async Task ThenTheResultIs(int result)
    {
        double actualResult = double.Parse(await service.GetResult());

        result.Should().Be((int)actualResult);
    }
}

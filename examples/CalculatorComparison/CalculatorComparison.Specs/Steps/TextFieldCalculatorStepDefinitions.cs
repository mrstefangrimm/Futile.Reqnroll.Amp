using CalculatorComparison.Specs.Services;
using FlaUI.Core.Tools;
using FluentAssertions;
using Reqnroll;

namespace CalculatorComparison.Specs.Steps;

[Binding]
public class TextFieldCalculatorStepDefinitions(TextFieldCalculatorService service)
{
    [Given("the futile calculator")]
    public void GivenTheFutileCalculator()
    {
        service.SelectFutileCalculator();
    }

    [Given("WPF Calculator")]
    public void GivenWPFCalculator()
    {
        service.SelectWpfCalculator();
    }

    [Given("the first number is {int}")]
    public async Task GivenTheFirstNumberIs(int p0)
    {
        await service.EnterFirstNumber(p0.ToString());
    }

    [Given("the second number is {int}")]
    public async Task GivenTheSecondNumberIs(int p0)
    {
        await service.EnterSecondNumber(p0.ToString());
    }

    [When("the two numbers are added")]
    public async Task WhenTheTwoNumbersAreAdded()
    {
        await service.ClickAdd();
    }

    [Then("the result should be {int}")]
    public async Task ThenTheResultShouldBe(int p0)
    {
        var actualResult = await service.GetResult();

        var actualInt = double.Parse(actualResult).ToInt();

        actualInt.Should().Be(p0);
    }
}

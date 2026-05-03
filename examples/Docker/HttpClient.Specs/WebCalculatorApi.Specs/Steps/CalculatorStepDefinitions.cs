using FluentAssertions;
using Reqnroll;
using WebCalculatorApi.Specs.Services;

namespace WebCalculatorApi.Specs.Steps;

[Binding]
public class CalculatorStepDefinitions(CalculatorService calculatorService)
{
    [Given("the first number is {int}")]
    public void GivenTheFirstNumberIs(int p0)
    {
        calculatorService.FirstNumber = p0;
    }

    [Given("the second number is {int}")]
    public void GivenTheSecondNumberIs(int p0)
    {
        calculatorService.SecondNumber = p0;
    }

    [When("the two numbers are added")]
    public async Task WhenTheTwoNumbersAreAdded()
    {
        calculatorService.MathOperator = "Add";
    }

    [Then("the result should be {double}")]
    public async Task ThenTheResultShouldBe(double p0)
    {
        double result = await calculatorService.App.GetResult(calculatorService.FirstNumber, calculatorService.SecondNumber, calculatorService.MathOperator);
        result.Should().Be(p0);
    }
}

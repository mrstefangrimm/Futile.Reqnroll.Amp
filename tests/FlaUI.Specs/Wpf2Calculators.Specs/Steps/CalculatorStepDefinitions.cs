using FlaUI.Core.Tools;
using FluentAssertions;
using Reqnroll;
using Wpf2Calculators.Specs.Services;

namespace Wpf2Calculators.Specs.Steps;

[Binding]
public class CalculatorStepDefinitions(ICalculatorService<Profile.One> calculatorOne, ICalculatorService<Profile.Two> calculatorTwo)
{
    [Given("the first number is {int}")]
    public void GivenTheFirstNumberIs(int p0)
    {
        calculatorOne.SwitchProfile();
        calculatorTwo.SwitchProfile();

        calculatorOne.MainWindow.EnterFirstNumber(p0.ToString());
        calculatorTwo.MainWindow.EnterFirstNumber(p0.ToString());
    }

    [Given("the second number is {int}")]
    public void GivenTheSecondNumberIs(int p0)
    {
        calculatorOne.MainWindow.EnterSecondNumber(p0.ToString());
        calculatorTwo.MainWindow.EnterSecondNumber(p0.ToString());
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        calculatorOne.MainWindow.ClickAdd();
        calculatorTwo.MainWindow.ClickAdd();
    }

    [Then("the result should be {int}")]
    public void ThenTheResultShouldBe(int p0)
    {
        var actualResultOne = calculatorOne.MainWindow.GetResult();
        var actualIntOne = double.Parse(actualResultOne).ToInt();

        actualIntOne.Should().Be(p0);

        var actualResultTwo = calculatorOne.MainWindow.GetResult();
        var actualIntTwo = double.Parse(actualResultTwo).ToInt();

        actualIntTwo.Should().Be(p0);
    }
}

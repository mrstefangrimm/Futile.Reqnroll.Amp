using FlaUI.Core.Tools;
using FluentAssertions;
using Reqnroll;
using Reqnroll.Amp;
using WpfCalculator.Specs.Services;

namespace WpfCalculator.Specs.Steps;

[Binding]
public class CalculatorStepDefinitions(ICalculatorService calculatorService, FlaUIDriver driver)
{
    [Given("the first number is {int}")]
    public void GivenTheFirstNumberIs(int p0)
    {
        calculatorService.MainWindow.EnterFirstNumber(p0.ToString());
    }

    [Given("the second number is {int}")]
    public void GivenTheSecondNumberIs(int p0)
    {
        calculatorService.MainWindow.EnterSecondNumber(p0.ToString());
    }

    [Given("profile with argument is selected")]
    public void GivenProfileWithArgumentIsSelected()
    {
        driver.SelectProfile("WPF Calculator with arguments");
    }

    [Given("profile without argument and the commandline argument is {string}")]
    public void GivenProfileWithoutArgumentAndTheCommandlineArgumentIs(string arg)
    {
        driver.SelectProfile("WPF Calculator", arg);
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        calculatorService.MainWindow.ClickAdd();
    }

    [Then("the result should be {int}")]
    public void ThenTheResultShouldBe(int p0)
    {
        var actualResult = calculatorService.MainWindow.GetResult();
        var actualInt = double.Parse(actualResult).ToInt();

        actualInt.Should().Be(p0);
    }

    [Then("the title is set to the profile's argument")]
    public void ThenTheTitleIsSetToTheProfilesArgument()
    {
        var title = calculatorService.MainWindow.Title;

        title.Text.Should().Be("Hello Profile");
    }

    [Then("the title is set to {string}")]
    public void ThenTheTitleIsSetTo(string arg)
    {
        var title = calculatorService.MainWindow.Title;

        title.Text.Should().Be(arg);
    }
}

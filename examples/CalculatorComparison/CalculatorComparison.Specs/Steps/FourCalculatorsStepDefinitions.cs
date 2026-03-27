using System;
using CalculatorComparison.Specs.Services;
using FlaUI.Core.Tools;
using FluentAssertions;
using Reqnroll;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CalculatorComparison.Specs.Steps
{
    [Binding]
    public class FourCalculatorsStepDefinitions(WpfCalculatorService wpfCalcservice, StoreAppCalculatorService storeAppCalcService, FutileWebCalculatorService futileCalcService, WebCalculatorService webCalcService)
    {
        [Given("the four Calculator")]
        public void GivenTheFourCalculator()
        {
            wpfCalcservice.SelectWpfCalculator();
            storeAppCalcService.SelectWindowsCalculator();
            futileCalcService.SelectFutileCalculator();
            webCalcService.SelectWebCalculator();
        }

        [Given("the first number for WPF is {int}")]
        public void GivenTheFirstNumberForWPFIs(int p0)
        {
            wpfCalcservice.MainWindow.EnterFirstNumber(p0.ToString());
        }

        [Given("the first number for Futile is {int}")]
        public async Task GivenTheFirstNumberForFutileIs(int p0)
        {
            await futileCalcService.MainPage.EnterFirstNumberAsync(p0.ToString());
        }

        [Given("the first number for StoreApp is {string}")]
        public void GivenTheFirstNumberForStoreAppIs(string p0)
        {
            foreach (char ch in p0)
            {
                storeAppCalcService.MainWindow.EnterNumber(ch);
            }
        }

        [Given("the first number for WebCalc is {string}")]
        public async Task GivenTheFirstNumberForWebCalcIs(string p0)
        {
            foreach (char ch in p0)
            {
                await webCalcService.MainPage.EnterNumberAsync(ch);
            }
        }

        [Given("Plus is pressed in StoreApp and WebCalc")]
        public async Task GivenPlusIsPressedInStoreAppAndWebCalc()
        {
            storeAppCalcService.MainWindow.ClickAdd();
            await webCalcService.MainPage.ClickAddAsync();
        }

        [Given("the second number for WPF is {int}")]
        public void GivenTheSecondNumberForWPFIs(int p0)
        {
            wpfCalcservice.MainWindow.EnterSecondNumber(p0.ToString());
        }

        [Given("the second number for Futile is {int}")]
        public async Task GivenTheSecondNumberForFutileIs(int p0)
        {
            await futileCalcService.MainPage.EnterSecondNumberAsync(p0.ToString());
        }

        [Given("the second number for StoreApp is {string}")]
        public void GivenTheSecondNumberForStoreAppIs(string p0)
        {
            foreach (char ch in p0)
            {
                storeAppCalcService.MainWindow.EnterNumber(ch);
            }
        }

        [Given("the second number for WebCalc is {string}")]
        public async Task GivenTheSecondNumberForWebCalcIs(string p0)
        {
            foreach (char ch in p0)
            {
                await webCalcService.MainPage.EnterNumberAsync(ch);
            }
        }

        [When("Add is pressed in WPF and Futile")]
        public async Task WhenAddIsPressedInWPFAndFutile()
        {
            wpfCalcservice.MainWindow.ClickAdd();
            await futileCalcService.MainPage.ClickAddAsync();
        }

        [When("Equal is pressed for StoreApp and WebCalc")]
        public async Task WhenEqualIsPressedForStoreAppAndWebCalc()
        {
            storeAppCalcService.MainWindow.ClickEqual();
            await webCalcService.MainPage.ClickEqualAsync();
        }

        [Then("the result in all should be {int}")]
        public async Task ThenTheResultInAllShouldBe(int p0)
        {
            var results = new string[]
            {
                wpfCalcservice.MainWindow.GetResult(),
                storeAppCalcService.MainWindow.GetResult(),
                await futileCalcService.MainPage.WaitForNonEmptyResultAsync(),
                await webCalcService.MainPage.WaitForNonEmptyResultAsync()
            };

            foreach (var result in results)
            {
                var actualInt = double.Parse(result).ToInt();
                actualInt.Should().Be(p0);
            }
        }
    }
}

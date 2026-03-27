namespace CalculatorComparison.Specs.Services;

public class TextFieldCalculatorService(FutileWebCalculatorService webCalcService, WpfCalculatorService wpfCalcService)
{
    private enum Impl
    {
        Web,
        Wpf
    }
    private Impl _impl;

    public void SelectFutileCalculator()
    {
        _impl = Impl.Web;
        webCalcService.SelectFutileCalculator();
    }

    public void SelectWpfCalculator()
    {
        _impl = Impl.Wpf;
        wpfCalcService.SelectWpfCalculator();
    }

    public async Task EnterFirstNumber(string number)
    {
        if (_impl == Impl.Web)
        {
            await webCalcService.MainPage.EnterFirstNumberAsync(number);
        }
        else
        {
            wpfCalcService.MainWindow.EnterFirstNumber(number);
        }
    }

    public async Task EnterSecondNumber(string number)
    {
        if (_impl == Impl.Web)
        {
            await webCalcService.MainPage.EnterSecondNumberAsync(number);
        }
        else
        {
            wpfCalcService.MainWindow.EnterSecondNumber(number);
        }
    }

    public async Task ClickAdd()
    {
        if (_impl == Impl.Web)
        {
            await webCalcService.MainPage.ClickAddAsync();
        }
        else
        {
            wpfCalcService.MainWindow.ClickAdd();
        }
    }

    public async Task<string> GetResult()
    {
        if (_impl == Impl.Web)
        {
            return await webCalcService.MainPage.WaitForNonEmptyResultAsync();
        }
        else
        {
            return wpfCalcService.MainWindow.GetResult();
        }
    }
}

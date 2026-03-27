namespace CalculatorComparison.Specs.Services;

public class NumFieldCalculatorService(WebCalculatorService webCalcService, StoreAppCalculatorService appCalcService)
{
    private enum Impl
    {
        Web,
        StoreApp
    }
    private Impl _impl;


    public void SelectWebCalculator()
    {
        _impl = Impl.Web;
        webCalcService.SelectWebCalculator();
    }

    public void SelectStoreAppCalculator()
    {
        _impl = Impl.StoreApp;
        appCalcService.SelectWindowsCalculator();
    }

    public async Task EnterNumber(char number)
    {
        if (_impl == Impl.Web)
        {
            await webCalcService.MainPage.EnterNumberAsync(number);
        }
        else
        {
            appCalcService.MainWindow.EnterNumber(number);
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
            appCalcService.MainWindow.ClickAdd();
        }
    }

    public async Task ClickEqual()
    {
        if (_impl == Impl.Web)
        {
            await webCalcService.MainPage.ClickEqualAsync();
        }
        else
        {
            appCalcService.MainWindow.ClickEqual();
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
            return appCalcService.MainWindow.GetResult();
        }
    }
}

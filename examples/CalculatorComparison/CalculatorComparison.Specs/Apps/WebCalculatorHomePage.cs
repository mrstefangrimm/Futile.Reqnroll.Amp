using Reqnroll.Amp;

namespace CalculatorComparison.Specs.Apps;

public class WebCalculatorHomePage
{
    private readonly PlayWrightDriver<Profile.Web> _driver;
    private readonly Lazy<IDictionary<char, string>> _numbersLazy;

    private static string AddSelector => "#plus";
    private static string EqualSelector => "#equal";
    private static string ResultSelector => "#result";

    public WebCalculatorHomePage(PlayWrightDriver<Profile.Web> driver)
    {
        _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        _numbersLazy = new Lazy<IDictionary<char, string>>(LoadNumbers);
    }

    private IDictionary<char, string> LoadNumbers()
    {
        Dictionary<char, string> buttons = new();
        buttons['1'] = "#num1";
        buttons['2'] = "#num2";
        buttons['3'] = "#num3";
        buttons['4'] = "#num4";
        buttons['5'] = "#num5";
        buttons['6'] = "#num6";
        buttons['7'] = "#num7";
        buttons['8'] = "#num8";
        buttons['9'] = "#num9";
        buttons['0'] = "#num0";

        return buttons;
    }

    public async Task EnterNumberAsync(char number)
    {
        await (await _driver.Stub).ClickAsync(_numbersLazy.Value[number]);
    }

    public async Task ClickAddAsync()
    {
        await (await _driver.Stub).ClickAsync(AddSelector);
    }

    public async Task ClickEqualAsync()
    {
        await (await _driver.Stub).ClickAsync(EqualSelector);
    }

    public async Task<string> WaitForNonEmptyResultAsync()
    {
        // Waits for the ResultLabelSelector value to be !== ""
        await (await _driver.Stub).WaitForFunctionAsync($"document.querySelector(\"{ResultSelector}\").value !== \"\"");

        // Gets the value attribute of the ResultSelector
        return await (await _driver.Stub).InputValueAsync(ResultSelector);
    }
}

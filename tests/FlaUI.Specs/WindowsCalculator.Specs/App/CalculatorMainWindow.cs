using System.Text.RegularExpressions;
using FlaUI.Core.AutomationElements;
using Reqnroll.Amp;

namespace WindowsCalculator.Specs.App;

public class CalculatorMainWindow
{
    private readonly FlaUIDriver _driver;
    private readonly Lazy<IDictionary<char, Button>> _numbersLazy;

    public CalculatorMainWindow(FlaUIDriver driver)
    {
        _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        _numbersLazy = new Lazy<IDictionary<char, Button>>(LoadNumbers);
    }

    private IDictionary<char, Button> LoadNumbers()
    {
        Dictionary<char, Button> buttons = new();
        buttons['1'] = _driver.Stub.FindFirstDescendant("num1Button").AsButton();
        buttons['2'] = _driver.Stub.FindFirstDescendant("num2Button").AsButton();
        buttons['3'] = _driver.Stub.FindFirstDescendant("num3Button").AsButton();
        buttons['4'] = _driver.Stub.FindFirstDescendant("num4Button").AsButton();
        buttons['5'] = _driver.Stub.FindFirstDescendant("num5Button").AsButton();
        buttons['6'] = _driver.Stub.FindFirstDescendant("num6Button").AsButton();
        buttons['7'] = _driver.Stub.FindFirstDescendant("num7Button").AsButton();
        buttons['8'] = _driver.Stub.FindFirstDescendant("num8Button").AsButton();
        buttons['9'] = _driver.Stub.FindFirstDescendant("num9Button").AsButton();
        buttons['0'] = _driver.Stub.FindFirstDescendant("num0Button").AsButton();

        return buttons;
    }

    public void EnterNumber(char number)
    {
        Numbers[number].Click();
    }

    public void ClickAdd()
    {
        ButtonAdd.Click();
    }

    public void ClickEqual()
    {
        ButtonEquals.Click();
    }

    public string GetResult()
    {
        var resultElement = Results;
        var value = resultElement.Properties.Name;
        return Regex.Replace(value, "[^0-9]", string.Empty);
    }

    internal IDictionary<char, Button> Numbers => _numbersLazy.Value;

    internal Button ButtonAdd => _driver.Stub.FindFirstDescendant("plusButton").AsButton();
    internal Button ButtonEquals => _driver.Stub.FindFirstDescendant("equalButton").AsButton();
    internal AutomationElement Results => _driver.Stub.FindFirstDescendant("CalculatorResults");
}

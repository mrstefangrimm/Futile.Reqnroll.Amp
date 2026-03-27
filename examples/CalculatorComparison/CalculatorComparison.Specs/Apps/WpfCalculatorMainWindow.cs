using FlaUI.Core.AutomationElements;
using Reqnroll.Amp;

namespace CalculatorComparison.Specs.Apps;

public class WpfCalculatorMainWindow
{
    private readonly FlaUIDriver<Profile.Wpf> _driver;

    public WpfCalculatorMainWindow(FlaUIDriver<Profile.Wpf> driver)
    {
        _driver = driver ?? throw new ArgumentNullException(nameof(driver));
    }

    public void EnterFirstNumber(string number)
    {
        FirstNumberTextBox.Text += number;
    }

    public void EnterSecondNumber(string number)
    {
        SecondNumberTextBox.Text += number;
    }

    public void ClickAdd()
    {
        AddButton.Click();
    }

    public string GetResult()
    {
        return ResultTextBox.Text;
    }

    public TextBox FirstNumberTextBox => _driver.Stub.FindFirstDescendant("TextBoxFirst").AsTextBox();
    public TextBox SecondNumberTextBox => _driver.Stub.FindFirstDescendant("TextBoxSecond").AsTextBox();
    public TextBox ResultTextBox => _driver.Stub.FindFirstDescendant("TextBoxResult").AsTextBox();

    public Button AddButton => _driver.Stub.FindFirstDescendant("ButtonAdd").AsButton();
    public Button SubtractButton => _driver.Stub.FindFirstDescendant("ButtonSubtract").AsButton();
    public Button MultiplyButton => _driver.Stub.FindFirstDescendant("ButtonMultiply").AsButton();
    public Button DivideButton => _driver.Stub.FindFirstDescendant("ButtonDivide").AsButton();
}

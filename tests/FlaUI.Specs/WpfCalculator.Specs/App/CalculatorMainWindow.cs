using FlaUI.Core.AutomationElements;
using Reqnroll.Amp;

namespace WpfCalculator.Specs.App;

public class CalculatorMainWindow(FlaUIDriver driver)
{
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

    public Label Title => driver.Stub.FindFirstDescendant("label_CommandlineArgs").AsLabel();
    public TextBox FirstNumberTextBox => driver.Stub.FindFirstDescendant("TextBoxFirst").AsTextBox();
    public TextBox SecondNumberTextBox => driver.Stub.FindFirstDescendant("TextBoxSecond").AsTextBox();
    public TextBox ResultTextBox => driver.Stub.FindFirstDescendant("TextBoxResult").AsTextBox();

    public Button AddButton => driver.Stub.FindFirstDescendant("ButtonAdd").AsButton();
    public Button SubtractButton => driver.Stub.FindFirstDescendant("ButtonSubtract").AsButton();
    public Button MultiplyButton => driver.Stub.FindFirstDescendant("ButtonMultiply").AsButton();
    public Button DivideButton => driver.Stub.FindFirstDescendant("ButtonDivide").AsButton();
}

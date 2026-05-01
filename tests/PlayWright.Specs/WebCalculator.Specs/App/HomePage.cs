using Reqnroll.Amp;

namespace WebCalculator.Specs.App;

public class HomePage(PlayWrightDriver driver)
{
    private static string FirstNumberFieldSelector => "#first-number";
    private static string SecondNumberFieldSelector => "#second-number";
    private static string AddButtonSelector => "#add-button";
    private static string ResultLabelSelector => "#result";

    public async Task EnterFirstNumberAsync(string number)
    {
        await (await driver.Stub).FillAsync(FirstNumberFieldSelector, number);
    }

    public async Task EnterSecondNumberAsync(string number)
    {
        await (await driver.Stub).FillAsync(SecondNumberFieldSelector, number);
    }

    public async Task ClickAddAsync()
    {
        await (await driver.Stub).ClickAsync(AddButtonSelector);
    }

    public async Task<string> WaitForNonEmptyResultAsync()
    {
        // Waits for the ResultLabelSelector value to be !== ""
        await (await driver.Stub).WaitForFunctionAsync($"document.querySelector(\"{ResultLabelSelector}\").value !== \"\"");

        // Gets the value attribute of the ResultLabelSelector
        return await (await driver.Stub).InputValueAsync(ResultLabelSelector);
    }
}

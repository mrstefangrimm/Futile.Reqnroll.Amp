using Reqnroll.Amp;

namespace CalculatorComparison.Specs.Apps;

public class FutileWebCalculatorHomePage(PlayWrightDriver<Profile.Futile> driver)
{
    private readonly PlayWrightDriver<Profile.Futile> _driver = driver;

    // TODO: Cleanup
    // The page URL
    //private protected const string CalculatorUrl = "https://futile-calculator.netlify.app/";

    //Finding elements by ID
    private static string FirstNumberFieldSelector => "#first-number";
    private static string SecondNumberFieldSelector => "#second-number";
    private static string AddButtonSelector => "#add-button";
    private static string ResultLabelSelector => "#result";
    private static string ResetButtonSelector => "#reset-button";

    public async Task EnterFirstNumberAsync(string number)
    {
        await (await _driver.Stub).FillAsync(FirstNumberFieldSelector, number);
    }

    public async Task EnterSecondNumberAsync(string number)
    {
        await (await _driver.Stub).FillAsync(SecondNumberFieldSelector, number);
    }

    public async Task ClickAddAsync()
    {
        await (await _driver.Stub).ClickAsync(AddButtonSelector);
    }

    //public async Task EnsureCalculatorIsOpenAndResetAsync()
    //{
    //    //Open the calculator page in the browser if not opened yet
    //    if ((await _page).Url != CalculatorUrl)
    //    {
    //        await _interactions.GoToUrl(CalculatorUrl);
    //    }
    //    //Otherwise reset the calculator by clicking the reset button
    //    else
    //    {
    //        //Click the rest button
    //        await _interactions.ClickAsync(ResetButtonSelector);

    //        //Wait until the result is empty again
    //        await WaitForEmptyResultAsync();
    //    }
    //}

    public async Task<string> WaitForNonEmptyResultAsync()
    {
        // Waits for the ResultLabelSelector value to be !== ""
        await (await _driver.Stub).WaitForFunctionAsync($"document.querySelector(\"{ResultLabelSelector}\").value !== \"\"");

        // Gets the value attribute of the ResultLabelSelector
        return await (await _driver.Stub).InputValueAsync(ResultLabelSelector);
    }

    //public async Task WaitForEmptyResultAsync()
    //{
    //    // Waits for the ResultLabelSelector value to be === ""
    //    await _interactions.WaitForEmptyValue(ResultLabelSelector);
    //}
}

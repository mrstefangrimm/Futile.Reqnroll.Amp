using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Reqnroll.Amp;

namespace CalculatorComparison.Specs.Apps;

public class WebApiCalculatorApiClient
{
    private readonly HttpClientDriver _driver;

    public WebApiCalculatorApiClient(HttpClientDriver driver)
    {
        _driver = driver;
    }

    public async Task<double> GetResult(int first, int second, string oper)
    {
        string json = JsonSerializer.Serialize(new CalcuationRequest(first, second, oper));
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _driver.Stub.PostAsync("", content);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<CalculationResponse>();
        return result.Result;
    }
}

public record CalcuationRequest(int FirstNumber, int SecondNumber, string MathOperation)
{
}

public record CalculationResponse(double Result)
{
}

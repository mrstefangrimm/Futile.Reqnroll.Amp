using WebCalculatorApi.Specs.App;

namespace WebCalculatorApi.Specs.Services;

public class CalculatorService(CalculatorApiClient api)
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
    public string MathOperator { get; set; }

    public CalculatorApiClient App { get; } = api;
}

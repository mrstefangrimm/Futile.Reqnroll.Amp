namespace Reqnroll.Amp;

[Binding]
public class ScreenCapturingHook(IScreenCapturing screenCapturing)
{
    [BeforeScenario]
    public void BeginScenario()
    {
        screenCapturing.StartRecording();
    }

    [AfterStep]
    public void AfterStep(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        screenCapturing?.TakeScreenshot(featureContext, scenarioContext);
    }

    [AfterScenario]
    public void AfterScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        screenCapturing?.StopRecording(featureContext, scenarioContext);
    }
}

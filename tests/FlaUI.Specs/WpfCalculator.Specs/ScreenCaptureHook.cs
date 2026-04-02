using Reqnroll.BoDi;

namespace Reqnroll.Amp;

[Binding]
public class ScreenCaptureHook(IScreenCapturer screenCapturer)
{
    //[BeforeTestRun]
    //public static void BeforeTestRun(IObjectContainer objectContainer)
    //{
    //    var screenCapturer = objectContainer.Resolve<IScreenCapturer>();
    //    screenCapturer?.StartRecording();
    //}

    [BeforeScenarioBlock]
    public void BeginScenarioBlock()
    {
        screenCapturer?.StartRecording();
    }

    [AfterStep]
    public void AfterStep(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        screenCapturer?.TakeScreenshot(featureContext, scenarioContext);
    }

    [AfterScenario]
    public void AfterScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        screenCapturer?.StopRecording(featureContext, scenarioContext);
    }

    [AfterScenarioBlock]
    public void EndScenarioBlock()
    {
        screenCapturer?.Dispose();
    }

    //[AfterTestRun]
    //public static void AfterTestRun(IObjectContainer objectContainer)
    //{
    //    var screenCapturer = objectContainer.Resolve<IScreenCapturer>();
    //    screenCapturer?.Dispose();
    //}
}

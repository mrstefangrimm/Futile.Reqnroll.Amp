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

    //[BeforeFeature]
    //public static void BeginScenarioBlock()
    //{
    //    //screenCapturer?.StartRecording();
    //}

    [BeforeScenario]
    public void BeginSecenario(IScreenCapturer screenCapturer)
    {
        // Start recording once, if a test run for more than one scenario is executed.
        if (!screenCapturer.IsRecording)
        {
            screenCapturer.StartRecording();
        }
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

    [AfterFeature]
    public static void EndScenarioBlock(IObjectContainer objectContainer)
    {
        //var screenCapturer = objectContainer.Resolve<IScreenCapturer>();
        //screenCapturer?.Dispose();
    }

    [AfterTestRun]
    public static void AfterTestRun(IObjectContainer objectContainer)
    {
        //var screenCapturer = objectContainer.Resolve<IScreenCapturer>();
        //screenCapturer?.Dispose();
    }
}

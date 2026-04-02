
namespace Reqnroll.Amp;

public interface IScreenCapturer : IDisposable
{
    void TakeScreenshot(FeatureContext featureContext, ScenarioContext scenarioContext);

    void StartRecording();
    void StopRecording(FeatureContext featureContext, ScenarioContext scenarioContext);
}

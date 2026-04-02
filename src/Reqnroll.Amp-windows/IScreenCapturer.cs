
namespace Reqnroll.Amp;

public interface IScreenCapturer : IDisposable
{
    void TakeScreenshot(FeatureContext featureContext, ScenarioContext scenarioContext);

    bool IsRecording { get; }
    void StartRecording();
    void StopRecording(FeatureContext featureContext, ScenarioContext scenarioContext);
}

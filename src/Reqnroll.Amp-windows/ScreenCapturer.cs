using FlaUI.Core.Capturing;
using Microsoft.Extensions.Options;

namespace Reqnroll.Amp;

public class ScreenCapturer : IScreenCapturer
{
    private readonly bool _takeScreenShots;
    private readonly bool _takeRecording;
    private readonly string? _outputPath;
    private readonly string? _ffmpegExecutable;
    private readonly string? _ffmpegTempFile;
    private readonly string CurrentDateTime = DateTime.Now.ToString("yyyy-MM-dd_Hmmss");

    private bool _isDisposed;
    private bool _recording;
    private VideoRecorder? _videoRecorder;

    public ScreenCapturer(IOptions<AmpSettings> configuration/*, ITestRunContext testRunContext*/)
    {
        if (configuration.Value.FlaUi.Settings.Capturing == null) return;

        _takeScreenShots = configuration.Value.FlaUi.Settings.Capturing!.Type == CapturingType.Screenshot;
        _takeRecording = configuration.Value.FlaUi.Settings.Capturing!.Type == CapturingType.Recording;

        _outputPath = configuration.Value.FlaUi.Settings.Capturing!.OutputPath != null
            ? configuration.Value.FlaUi.Settings.Capturing!.OutputPath
            : throw new Exception(); // Path.Combine(testRunContext.TestDirectory, "Capture");

        _ffmpegExecutable = _takeRecording ? configuration.Value.FlaUi.Settings.Capturing!.FFMPEG! : string.Empty;
        _ffmpegTempFile = Path.GetTempFileName();
    }

    public void Dispose()
    {
        if (!_isDisposed)
        {
            _isDisposed = true;
            _videoRecorder?.Dispose();
        }
    }

    public void TakeScreenshot(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        if (_takeScreenShots)
        {
            if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
            {
                var img = Capture.Screen();
                img.ApplyOverlays(new MouseOverlay(img));

                Directory.CreateDirectory(_outputPath!);
                string filename = $"{CurrentDateTime} {featureContext.FeatureInfo.Title} {scenarioContext.ScenarioInfo.Title} {scenarioContext.ScenarioExecutionStatus}.png";
                img.ToFile(Path.Combine(_outputPath!, filename));
            }
        }
    }

    public bool IsRecording => _recording;

    public void StartRecording()
    {
        if (_takeRecording)
        {
            _recording = true;
            _videoRecorder?.Dispose();
            _videoRecorder = new VideoRecorder(
                new VideoRecorderSettings
                {
                    VideoQuality = 26,
                    ffmpegPath = _ffmpegExecutable,
                    TargetVideoPath = _ffmpegTempFile
                },
                r =>
                {
                    var img = Capture.Screen();
                    img.ApplyOverlays(new InfoOverlay(img) { RecordTimeSpan = r.RecordTimeSpan, OverlayStringFormat = @"{rt:hh\:mm\:ss\.fff} / {name} / CPU: {cpu} / RAM: {mem.p.used}/{mem.p.tot} ({mem.p.used.perc})" }, new MouseOverlay(img));
                    return img;
                });
        }
    }

    public void StopRecording(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        if (_recording)
        {
            _videoRecorder?.Stop();
            _videoRecorder?.Dispose();
            _videoRecorder = null;
            _recording = false;

            if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
            {
                Directory.CreateDirectory(_outputPath!);
                string filename = $"{CurrentDateTime} {featureContext.FeatureInfo.Title} {scenarioContext.ScenarioInfo.Title} {scenarioContext.ScenarioExecutionStatus}.mpg";
                File.Move(_ffmpegTempFile!, Path.Combine(_outputPath!, filename));
            }
            else
            {
                File.Delete(_ffmpegTempFile!);
            }
        }
    }
}

using FlaUI.Core.Capturing;
using Microsoft.Extensions.Options;

namespace Reqnroll.Amp;

public interface IScreenCapturing : IDisposable
{
    void TakeScreenshot(FeatureContext featureContext, ScenarioContext scenarioContext);

    bool IsRecording { get; }
    void StartRecording();
    void StopRecording(FeatureContext featureContext, ScenarioContext scenarioContext);
}

public class ScreenCapturing : IScreenCapturing
{
    private readonly bool _takeScreenShots;
    private readonly bool _takeRecording;
    private readonly string? _outputPath;
    private readonly string? _ffmpegExecutable;
    private readonly string? _ffmpegTempFile;
    private readonly string CurrentDateTime = DateTime.Now.ToString("yyyy-MM-dd_Hmmss");

    private bool _disposed;
    private bool _recording;
    private VideoRecorder? _videoRecorder;

    public ScreenCapturing(IOptions<AmpSettings> configuration)
    {
        if (configuration.Value.FlaUi.Settings.Capturing == null) return;

        _takeScreenShots = configuration.Value.FlaUi.Settings.Capturing.Type == CapturingType.Screenshot;
        _takeRecording = configuration.Value.FlaUi.Settings.Capturing.Type == CapturingType.Recording;

        _outputPath = configuration.Value.FlaUi.Settings.Capturing.OutputPath != null
            ? configuration.Value.FlaUi.Settings.Capturing.OutputPath
            : throw new InvalidOperationException($"Invalid or misssing FlaUI screen capturing output path.");

        _ffmpegExecutable = _takeRecording ? configuration.Value.FlaUi.Settings.Capturing.FFMPEG : string.Empty;
        _ffmpegTempFile = Path.GetRandomFileName();
    }

    ~ScreenCapturing()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed || !disposing)
        {
            return;
        }

        _videoRecorder?.Dispose();
        _disposed = true;
    }

    public void TakeScreenshot(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        if (_takeScreenShots && scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
        {
            var img = Capture.Screen();
            img.ApplyOverlays(new MouseOverlay(img));

            Directory.CreateDirectory(_outputPath!);
            string filename = $"{CurrentDateTime} {featureContext.FeatureInfo.Title} {scenarioContext.ScenarioInfo.Title} {scenarioContext.ScenarioExecutionStatus}.png";
            img.ToFile(Path.Combine(_outputPath!, filename));
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
                    VideoFormat = VideoFormat.xvid,
                    VideoQuality = 5,
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
                string filename = $"{CurrentDateTime} {featureContext.FeatureInfo.Title} {scenarioContext.ScenarioInfo.Title} {scenarioContext.ScenarioExecutionStatus}.mp4";
                File.Move(_ffmpegTempFile!, Path.Combine(_outputPath!, filename));
            }
            else
            {
                File.Delete(_ffmpegTempFile!);
            }
        }
    }
}

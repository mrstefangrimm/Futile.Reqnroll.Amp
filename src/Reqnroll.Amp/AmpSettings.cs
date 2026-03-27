namespace Reqnroll.Amp;

public class AmpSettings
{
    public PlaywrightConfiguration Playwright { get; set; } = null!;
    public WebApiConfiguration WebApi { get; set; } = null!;
    public FlaUIConfiguration FlaUi { get; set; } = null!;
}

public class PlaywrightConfiguration
{
    public Dictionary<string, PlaywrightProfile> Profiles { get; set; } = null!;
}

public class PlaywrightProfile
{
    public string Url { get; set; } = null!;
    public bool Headless { get; set; } = false;
    public int SlowMo { get; set; } = 200;
    public string ChromeExecutablePath { get; set; } = null!;
}

public class WebApiConfiguration
{
    public Dictionary<string, WebApiProfile> Profiles { get; set; } = null!;
}

public class WebApiProfile
{
    public string Url { get; set; } = null!;
}

public class FlaUIConfiguration
{
    public FlaUISettings Settings { get; set; } = null!;
    public Dictionary<string, FlaUIProfile> Profiles { get; set; } = null!;
}

public class FlaUISettings
{
    public FlaUIA? UIA { get; set; } = null;
    public ErrorCapturing Capturing { get; set; } = null!;
}

public class FlaUIProfile
{
    public string App { get; set; } = null!;

    public string Arguments { get; set; } = null!;

    public LaunchCommand? Launch { get; set; } = null;
}

public class ErrorCapturing
{
    public CapturingType? Type { get; set; } = null;
    public string OutputPath { get; set; } = null!;
    public string FFMPEG { get; set; } = null!;
}

public enum FlaUIA
{
    UIA2,
    UIA3,
}

public enum CapturingType
{
    Screenshot,
    Recording,
}

public enum LaunchCommand
{
    Exe,
    StoreApp,
}

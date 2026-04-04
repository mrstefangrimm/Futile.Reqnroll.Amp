using Microsoft.Extensions.Options;
using Microsoft.Playwright;

namespace Reqnroll.Amp;

public class PlayWrightDriverBase : AmpDriver<Task<IPage>>, IDisposable, IAsyncDisposable
{
    private IPage? _homePage;
    private bool _disposed;

    public PlayWrightDriverBase(IOptions<AmpSettings> appSettings, IDriverInstanceFactory<Task<IPage>>? instanceFactory) : base(appSettings, instanceFactory) { }

    ~PlayWrightDriverBase()
    {
        Dispose(false);
    }

    protected override async Task<IPage> LaunchProfile()
    {
        if (_instanceFactory != null)
        {
            return await _instanceFactory.Create();
        }

        var apiSettings = _appSettings.Value.Playwright;

        var profiles = apiSettings.Profiles;
        if (profiles == null || !profiles.Any()) { throw new InvalidOperationException("No FlaUI profile defined."); }

        if (_launchProfileName == null)
        {
            _launchProfileName = profiles.First().Key;
            if (_launchProfileName == null || string.IsNullOrEmpty(_launchProfileName)) { throw new InvalidOperationException($"Invalid FlaUI profile name {_launchProfileName}."); }
        }

        var profile = profiles[_launchProfileName];
        if (profile == null) { throw new InvalidOperationException($"Invalid profile with name {_launchProfileName}."); }

        var playwright = await Playwright.CreateAsync().ConfigureAwait(false);
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = profile.Headless,
            SlowMo = profile.SlowMo,
            ExecutablePath = profile.ChromeExecutablePath
        }).ConfigureAwait(false);

        _homePage = await browser.NewPageAsync().ConfigureAwait(false);

        await _homePage.GotoAsync(_launchArguments ?? profile.Url);

        return _homePage;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }

        if (_homePage != null && !_homePage.IsClosed)
        {
            await _homePage.CloseAsync();
            _homePage = null;
        }

        _disposed = true;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed || !disposing)
        {
            return;
        }

        if (_homePage != null && !_homePage.IsClosed)
        {
            var closingTask = _homePage.CloseAsync();
            closingTask.Wait(TimeSpan.FromSeconds(5));
            _homePage = null;
        }

        _disposed = true;
    }
}

public sealed class PlayWrightDriver : PlayWrightDriverBase
{
    public PlayWrightDriver(IOptions<AmpSettings> appSettings) : base(appSettings, null) { }
    public PlayWrightDriver(IOptions<AmpSettings> appSettings, IDriverInstanceFactory<Task<IPage>> instanceFactory) : base(appSettings, instanceFactory) { }
}

public sealed class PlayWrightDriver<N> : PlayWrightDriverBase
{
    public PlayWrightDriver(IOptions<AmpSettings> appSettings) : base(appSettings, null) { }
    public PlayWrightDriver(IOptions<AmpSettings> appSettings, IDriverInstanceFactory<Task<IPage>> instanceFactory) : base(appSettings, instanceFactory) { }
}

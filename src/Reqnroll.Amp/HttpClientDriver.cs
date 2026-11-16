using Microsoft.Extensions.Options;

namespace Reqnroll.Amp;

public class HttpClientDriverBase : AmpDriver<HttpClient>, IDisposable
{
    private HttpClient? _instance;
    private bool _disposed;

    public HttpClientDriverBase(IOptions<AmpSettings> appSettings, IDriverInstanceFactory<HttpClient>? instanceFactory) : base(appSettings, instanceFactory) { }

    ~HttpClientDriverBase()
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

        if (_instance != null)
        {
            _instance.Dispose();
            _instance = null;
        }

        _disposed = true;
    }

    protected override HttpClient LaunchProfile()
    {
        if (_instanceFactory != null)
        {
            return _instanceFactory.Create();
        }

        var apiSettings = _appSettings.Value.WebApi;
        var profile = GetLaunchProfile(apiSettings.Profiles, _launchProfileName);
        if (profile == null) { throw new InvalidOperationException($"Invalid profile with name {_launchProfileName}."); }

        _instance = new HttpClient
        {
            BaseAddress = new Uri(_launchArguments ?? profile.Url)
        };

        return _instance;
    }
}

public class HttpClientDriver : HttpClientDriverBase
{
    public HttpClientDriver(IOptions<AmpSettings> appSettings) : base(appSettings, null) { }
    public HttpClientDriver(IOptions<AmpSettings> appSettings, IDriverInstanceFactory<HttpClient> instanceFactory) : base(appSettings, instanceFactory) { }
}

public class HttpClientDriver<N> : HttpClientDriverBase
{
    public HttpClientDriver(IOptions<AmpSettings> appSettings) : base(appSettings, null) { }
    public HttpClientDriver(IOptions<AmpSettings> appSettings, IDriverInstanceFactory<HttpClient> instanceFactory) : base(appSettings, instanceFactory) { }
}

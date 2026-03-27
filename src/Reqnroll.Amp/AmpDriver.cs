using Microsoft.Extensions.Options;

namespace Reqnroll.Amp;

public abstract class AmpDriver<T>
{
    protected IOptions<AmpSettings> _appSettings;
    protected string? _launchProfileName;
    protected string? _launchArguments;
    protected Lazy<T> _lazyInstance;
    protected IDriverInstanceFactory<T>? _instanceFactory;

    public AmpDriver(IOptions<AmpSettings> appSettings, IDriverInstanceFactory<T>? instanceFactory)
    {
        _appSettings = appSettings;
        _instanceFactory = instanceFactory;
        _lazyInstance = new Lazy<T>(LaunchProfile);
    }

    /// <summary>
    /// The tested object with can be a window (flaui), a web page (playwright), a http connection.
    /// </summary>
    public T Stub => _lazyInstance.Value;

    /// <summary>
    /// Select the test profile. This must be done before Stub is called.
    /// </summary>
    /// <exception cref="InvalidOperationException">thrown is Stub was called before.</exception>
    public void SelectProfile(string profileName, string? launchArguments = null)
    {
        if (_lazyInstance.IsValueCreated)
        {
            throw new InvalidOperationException("switch profile on launched application is not possible.");
        }

        _launchProfileName = profileName;
        _launchArguments = launchArguments;
    }

    protected abstract T LaunchProfile();
}

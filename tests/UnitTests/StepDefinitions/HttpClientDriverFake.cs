using Microsoft.Extensions.Options;
using Reqnroll.Amp;

namespace UnitTests.StepDefinitions
{
    public sealed partial class CalculatorStepDefinitions
    {
        class HttpClientDriverFake : AmpDriver<HttpClientDriver>
        {
            public HttpClientDriverFake(IOptions<AmpSettings> appSettings, IDriverInstanceFactory<HttpClientDriver>? instanceFactory) : base(appSettings, instanceFactory)
            {
                throw new NotSupportedException();
            }

            protected override HttpClientDriver LaunchProfile()
            {
                throw new NotSupportedException();
            }

            internal static WebApiProfile GetProfile(IDictionary<string, WebApiProfile>? profiles, string? profileName)
            {
                return GetLaunchProfile(profiles, profileName);
            }
        }
    }
}

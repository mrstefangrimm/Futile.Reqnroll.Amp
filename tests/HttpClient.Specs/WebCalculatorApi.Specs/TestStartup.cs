using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Reqnroll.Amp;
using Reqnroll.Autofac;
using WebCalculatorApi.Specs.App;
using WebCalculatorApi.Specs.Services;
using WebCalculatorApi.Specs.Steps;

namespace WebCalculatorApi.Specs;

public static class TestStartup
{
    [ScenarioDependencies]
    public static void CreateServices(ContainerBuilder builder)
    {
        builder.RegisterConfiguration();
        builder.RegisterAppSettings();

        builder.RegisterType<CalculatorStepDefinitions>().InstancePerDependency();
        builder.RegisterType<CalculatorService>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<CalculatorApiClient>().AsSelf().InstancePerDependency();
        builder.RegisterType<HttpClientDriver>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<HttpClientFactory>().As<IDriverInstanceFactory<HttpClient>>().InstancePerLifetimeScope();

        var factory = new CustomWebApplicationFactory();
        HttpClientFactory.Instance = factory.CreateClient();
        HttpClientFactory.Instance.BaseAddress = new Uri("http://localhost/api/calculation");
    }
}

internal class HttpClientFactory : IDriverInstanceFactory<HttpClient>
{
    public static HttpClient Instance { get; set; }

    public HttpClient Create()
    {
        return Instance;
    }
}

internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Intentionally commented out code.
            // CalculationService should not be mocked. It is stateless and has no dependencies.
            // The commented out code show how you could do the mocking.

            // Remove the service
            // var descriptor = services.Single(d => d.ServiceType == typeof(ICalculationService));
            // services.Remove(descriptor);

            // Add your mock
            //services.AddScoped<ICalculationService, CalculationMockService>();
        });
    }
}

using Autofac;
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
    }
}

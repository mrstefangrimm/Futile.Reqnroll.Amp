using Autofac;
using Reqnroll.Amp;
using Reqnroll.Autofac;
using WindowsCalculator.Specs.App;
using WindowsCalculator.Specs.Services;
using WindowsCalculator.Specs.Steps;

namespace WindowsCalculator.Specs;

public static class TestStartup
{
    [ScenarioDependencies]
    public static void CreateServices(ContainerBuilder builder)
    {
        builder.RegisterConfiguration();
        builder.RegisterAppSettings();

        builder.RegisterType<CalculatorStepDefinitions>().InstancePerDependency();
        builder.RegisterType<CalculatorMainWindow>().AsSelf().InstancePerDependency();
        builder.RegisterType<CalculatorService>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<FlaUIDriver>().AsSelf().InstancePerLifetimeScope();
    }
}

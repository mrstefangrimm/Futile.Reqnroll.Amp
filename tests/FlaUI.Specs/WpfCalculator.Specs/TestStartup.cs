using Autofac;
using Reqnroll.Amp;
using Reqnroll.Autofac;
using WpfCalculator.Specs.App;
using WpfCalculator.Specs.Services;
using WpfCalculator.Specs.Steps;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace WpfCalculator.Specs;

public static class TestStartup
{
    [ScenarioDependencies]
    public static void CreateServices(ContainerBuilder builder)
    {
        builder.RegisterConfiguration();
        builder.RegisterAppSettings();

        builder.RegisterType<CalculatorStepDefinitions>().InstancePerDependency();
        builder.RegisterType<CalculatorMainWindow>().AsSelf().InstancePerDependency();
        builder.RegisterType<CalculatorService>().As<ICalculatorService>().InstancePerLifetimeScope();
        builder.RegisterType<FlaUIDriver>().AsSelf().InstancePerLifetimeScope();
    }
}

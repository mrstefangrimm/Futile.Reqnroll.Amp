using Autofac;
using CalculatorComparison.Specs.Apps;
using CalculatorComparison.Specs.Services;
using CalculatorComparison.Specs.Steps;
using Reqnroll.Amp;
using Reqnroll.Autofac;

namespace CalculatorComparison.Specs;

public static class Profile
{
    public struct Wpf { };
    public struct Windows { };
    public struct Futile { };
    public struct Web { };
}

public static class TestStartup
{
    [ScenarioDependencies]
    public static void CreateServices(ContainerBuilder builder)
    {
        builder.RegisterConfiguration();
        builder.RegisterAppSettings();

        builder.RegisterWpfCalculator();
        builder.RegisterStoreAppCalculator();
        builder.RegisterFutileCalculator();
        builder.RegisterWebCalculator();

        builder.RegisterType<TextFieldCalculatorStepDefinitions>().InstancePerDependency();
        builder.RegisterType<TextFieldCalculatorService>().AsSelf().InstancePerLifetimeScope();

        builder.RegisterType<NumFieldCalculatorStepDefinitions>().InstancePerDependency();
        builder.RegisterType<NumFieldCalculatorService>().AsSelf().InstancePerLifetimeScope();

        builder.RegisterType<FourCalculatorsStepDefinitions>().InstancePerDependency();
    }

    private static void RegisterWpfCalculator(this ContainerBuilder builder)
    {
        builder.RegisterType<WpfCalculatorService>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<WpfCalculatorMainWindow>().AsSelf().InstancePerDependency();
        builder.RegisterType<FlaUIDriver<Profile.Wpf>>().AsSelf().InstancePerLifetimeScope();
    }

    private static void RegisterStoreAppCalculator(this ContainerBuilder builder)
    {
        builder.RegisterType<StoreAppCalculatorService>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<StoreAppCalculatorMainWindow>().AsSelf().InstancePerDependency();
        builder.RegisterType<FlaUIDriver<Profile.Windows>>().AsSelf().InstancePerLifetimeScope();
    }

    private static void RegisterFutileCalculator(this ContainerBuilder builder)
    {
        builder.RegisterType<FutileWebCalculatorService>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<FutileWebCalculatorHomePage>().AsSelf().InstancePerDependency();
        builder.RegisterType<PlayWrightDriver<Profile.Futile>>().AsSelf().InstancePerLifetimeScope();
    }

    private static void RegisterWebCalculator(this ContainerBuilder builder)
    {
        builder.RegisterType<WebCalculatorService>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<WebCalculatorHomePage>().AsSelf().InstancePerDependency();
        builder.RegisterType<PlayWrightDriver<Profile.Web>>().AsSelf().InstancePerLifetimeScope();
    }
}

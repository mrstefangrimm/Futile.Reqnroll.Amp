using Autofac;
using Reqnroll.Amp;
using Reqnroll.Autofac;
using Wpf2Calculators.Specs.App;
using Wpf2Calculators.Specs.Services;
using Wpf2Calculators.Specs.Steps;

namespace Wpf2Calculators.Specs;

public static class Profile
{
    public struct One { }
    public struct Two { }
}

public static class TestStartup
{
    [ScenarioDependencies]
    public static void CreateServices(ContainerBuilder builder)
    {
        builder.RegisterConfiguration();
        builder.RegisterAppSettings();

        builder.RegisterType<CalculatorStepDefinitions>().InstancePerDependency();
        builder.RegisterType<CalculatorServiceOne>().As<ICalculatorService<Profile.One>>().InstancePerLifetimeScope();
        builder.RegisterType<CalculatorServiceTwo>().As<ICalculatorService<Profile.Two>>().InstancePerLifetimeScope();
        builder.RegisterType<CalculatorMainWindow<Profile.One>>().AsSelf().InstancePerDependency();
        builder.RegisterType<CalculatorMainWindow<Profile.Two>>().AsSelf().InstancePerDependency();
        builder.RegisterType<FlaUIDriver<Profile.One>>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<FlaUIDriver<Profile.Two>>().AsSelf().InstancePerLifetimeScope();
    }
}

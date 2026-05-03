using Autofac;
using Reqnroll.Amp;
using Reqnroll.Autofac;
using WebCalculator.Specs.App;
using WebCalculator.Specs.Services;
using WebCalculator.Specs.Steps;

namespace WebCalculator.Specs
{
    public static class TestStartup
    {
        [ScenarioDependencies]
        public static void CreateServices(ContainerBuilder builder)
        {
            builder.RegisterConfiguration();
            builder.RegisterAppSettings();

            builder.RegisterType<CalculatorStepDefinitions>().InstancePerDependency();
            builder.RegisterType<CalculatorService>().As<ICalculatorService>().InstancePerLifetimeScope();
            builder.RegisterType<HomePage>().AsSelf().InstancePerDependency();
            builder.RegisterType<PlayWrightDriver>().AsSelf().InstancePerLifetimeScope();
        }
    }
}

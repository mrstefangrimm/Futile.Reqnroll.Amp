using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Reqnroll.Amp;

public static class ContainerBuilderExtension
{
    extension(ContainerBuilder builder)
    {
        public void RegisterConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("reqnroll.ampsettings.json", false, true)
                .Build();

            builder.RegisterInstance(configuration)
                .As<IConfiguration>()
                .SingleInstance();
        }

        public void RegisterAppSettings()
        {
            builder.Register(c =>
            {
                var configuration = c.Resolve<IConfiguration>();
                var appSettings = new AmpSettings();
                configuration.Bind(appSettings);
                return Options.Create(appSettings);
            }).As<IOptions<AmpSettings>>();
        }
    }
}

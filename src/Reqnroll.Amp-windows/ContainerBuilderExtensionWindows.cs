using Autofac;

namespace Reqnroll.Amp;

public static class ContainerBuilderExtensionWindows
{
    extension(ContainerBuilder builder)
    {
        public void RegisterScreenCapturer()
        {
            builder.RegisterType<ScreenCapturer>().As<IScreenCapturer>();
            builder.RegisterType<ScreenCaptureHook>().AsSelf().InstancePerLifetimeScope();
        }
    }
}

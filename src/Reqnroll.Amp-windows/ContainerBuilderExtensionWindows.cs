using Autofac;

namespace Reqnroll.Amp;

public static class ContainerBuilderExtensionWindows
{
    extension(ContainerBuilder builder)
    {
        public void RegisterScreenCapturing()
        {
            builder.RegisterType<ScreenCapturing>().As<IScreenCapturing>();
            builder.RegisterType<ScreenCapturingHook>().AsSelf();
        }
    }
}

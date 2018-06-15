using Autofac;
using Autofac.Integration.Mvc;
using LocalOnlyAccessTest.Authorization.Models;
using LocalOnlyAccessTest.Authorization.Providers;

namespace LocalOnlyAccessTest.IoC
{
    public static class AutofacContainerFactory
    {
        public static IContainer Create()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);

            builder.RegisterModelBinderProvider();

            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterSource(new ViewRegistrationSource());

            builder.RegisterFilterProvider();

            builder.RegisterType<IpAddressProvider>().As<IProvideIpAddresses>().SingleInstance();
            builder.Register(x => x.Resolve<IProvideIpAddresses>().GetLocalIPs()).As<NetworkInfo>().SingleInstance();

            var container = builder.Build();

            return container;
        }
    }
}
using System;
using System.Linq;
using Autofac;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public static class AutofacSetup
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder = RegisterAssemblies(builder);
            return builder.Build();
        }

        public static ContainerBuilder RegisterAssemblies(ContainerBuilder containerBuilder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .ToList();
                //.Where(x => x.FullName.Contains("SoftwareEngineeringNetwork.JournalApplication"))
                //.ToList();

            foreach (var assembly in assemblies)
                containerBuilder.RegisterAssemblyModules(assembly);

            return containerBuilder;
        }
    }
}

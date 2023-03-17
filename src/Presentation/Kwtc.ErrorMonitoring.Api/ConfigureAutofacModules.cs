namespace Kwtc.ErrorMonitoring.Api;

using System.Reflection;
using System.Text.RegularExpressions;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

public static class ConfigureAutofacModules
{
    public static void RegisterAutofacModules(this WebApplicationBuilder? builder)
    {
        if (builder == null)
        {
            return;
        }

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            var assemblyRegex = new Regex("^(Kwtc)((\\..+)|$)");
            var assemblies = DependencyContext.Default?.RuntimeLibraries
                                              .Where(lib => assemblyRegex.IsMatch(lib.Name))
                                              .SelectMany(lib => lib.GetDefaultAssemblyNames(DependencyContext.Default))
                                              .Select(Assembly.Load).ToArray();

            if (assemblies == null)
            {
                return;
            }

            containerBuilder.RegisterAssemblyModules(assemblies);
        });
    }
}

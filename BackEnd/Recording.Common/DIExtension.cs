
using Microsoft.Extensions.DependencyInjection;
using Recording.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Recording.Common
{

    public static class DIExtension
        {
            public static void ServiceRegister(this IServiceCollection services, params Assembly[] assemblies)
            {
                if (assemblies.Count() <= 0)
                {
                    return;
                }
                foreach (var assembly in assemblies)
                {

                    var allTypes = assembly.GetTypes();
                    foreach (var type in allTypes)
                    {
                        if (typeof(ITransientDependency).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                        {

                            var interfaceTypes = type.GetInterfaces().Where(p => !p.FullName.Contains("ITransientDependency"));
                            foreach (var interfaceType in interfaceTypes)
                            {
                                services.AddTransient(interfaceType, type);
                            }
                        }
                    }

                    foreach (var type in allTypes)
                    {
                        if (typeof(ISingletonDependency).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                        {
                          
                            var interfaceTypes = type.GetInterfaces().Where(p => !p.FullName.Contains("ISingletonDependency"));
                            foreach (var interfaceType in interfaceTypes)
                            {
                                services.AddSingleton(interfaceType, type);
                            }
                        }
                    }

                    foreach (var type in allTypes)
                    {
                        if (typeof(IScopedDependency).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                        {
                       
                            var interfaceTypes = type.GetInterfaces().Where(p => !p.FullName.Contains("IScopedDependency"));
                            foreach (var interfaceType in interfaceTypes)
                            {
                                services.AddScoped(interfaceType, type);
                            }
                        }
                    }
                }

            }
        }
    
}

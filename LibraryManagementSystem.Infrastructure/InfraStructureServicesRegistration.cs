using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure
{
    public static class InfraStructureServicesRegistration
    {
        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services)
        {
            return services;
        }
    }
}

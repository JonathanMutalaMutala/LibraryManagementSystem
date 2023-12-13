using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application
{
    /// <summary>
    /// Classe permettant d'ajouter les services IServiceCollection
    /// </summary>
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            // Ajout du service autoMapper à la collection des services 
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            // Ajout du services MediatR dans la collection de services 
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}

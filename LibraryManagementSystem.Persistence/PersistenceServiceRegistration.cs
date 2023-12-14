using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using LibraryManagementSystem.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Application.Contracts.Persistence;
using LibraryManagementSystem.Persistence.Repositories;

namespace LibraryManagementSystem.Persistence
{
    public static class PersistenceServiceRegistration
    {
        /// <summary>
        /// Ce service sera ajouter dans le program.cs de la Web Api 
        /// Ce service permettra d'enregister la dbContext pour permettre de faire les operations des Repository
        /// </summary>
        /// <param name=""></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<LibraryManagementSystemDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LibraryDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IBookRepository, BookRepository>(); 

            return services;
        }
    }
}

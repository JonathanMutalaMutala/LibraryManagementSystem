﻿using Library.BlazorUI.Contracts.Account;
using Library.BlazorUI.Contracts.Book;
using Library.BlazorUI.Services.AccountServices;
using Library.BlazorUI.Services.BookServices;

namespace Library.BlazorUI.Configuration
{
    public static class ContractsServiceRegistration
    {
        public static IServiceCollection AddContractsServices(this IServiceCollection services)
        {
            services.AddScoped­­<IBookService, BookService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}

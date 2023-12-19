using Library.BlazorUI.Contracts.Book;
using Library.BlazorUI.Services.BookServices;

namespace Library.BlazorUI.Configuration
{
    public static class ContractsServiceRegistration
    {
        public static IServiceCollection AddContractsServices(this IServiceCollection services)
        {
            services.AddScoped­­<IBookService, BookService>();

            return services;
        }
    }
}

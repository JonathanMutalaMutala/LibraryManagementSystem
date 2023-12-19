using AutoMapper;
using Library.BlazorUI.Contracts.Book;
using Library.BlazorUI.Models.BookModel;
using Library.BlazorUI.Services.Base;
using Library.BlazorUI.Services.Base.Client;
using Library.BlazorUI.Services.Base.HttpService;

namespace Library.BlazorUI.Services
{
    public class BookService : BaseHttpService, IBookService
    {
        public BookService(IClient clientService, IMapper mapper) : base(clientService, mapper)
        {
        }

        public Task<List<BookVM>> GetAllBooks()
        {
            throw new  NotImplementedException();
        }

        public async Task<Response<Guid>> GetAllBooksResponse()
        {
            //try
            //{
            //    var getAllBooks = await _clientService.
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
            throw new NotImplementedException();
            
        }
    }
}

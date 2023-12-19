using AutoMapper;
using Library.BlazorUI.Contracts.Book;
using Library.BlazorUI.Models.BookModel;
using Library.BlazorUI.Services.Base;

namespace Library.BlazorUI.Services
{
    public class BookService : BaseHttpService, IBookService
    {
        public Task<List<BookVM>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Task<Response<Guid>> GetAllBooksResponse()
        {
            throw new NotImplementedException();
        }
    }
}

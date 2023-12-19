using Library.BlazorUI.Models.BookModel;
using Library.BlazorUI.Services.Base;

namespace Library.BlazorUI.Contracts.Book
{
    public interface IBookService
    {
        Task<List<BookVM>> GetAllBooks(); 
        
        Task<Response<Guid>> GetAllBooksResponse();
    }
}

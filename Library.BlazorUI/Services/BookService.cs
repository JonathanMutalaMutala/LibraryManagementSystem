using AutoMapper;
using Library.BlazorUI.Contracts.Book;
using Library.BlazorUI.Models.BookModel;
using Library.BlazorUI.Services.Base;

namespace Library.BlazorUI.Services
{
    public class BookService : BaseHttpService, IBookService
    {
        public BookService(IMapper mapper, IClient client) : base(mapper, client)
        {
        }

        public async Task<List<BookVM>> GetAllBooks()
        {
            var getAllBooks = await _client.BookAllAsync();

            var mapper = _mapper.Map<List<BookVM>>(getAllBooks);

            return mapper; 
        }

        public async Task<Response<List<BookVM>>> GetAllBooksResponse()
        {
            var _getAllBooks = await _client.BookAllAsync();

            var response = new Response<List<BookVM>>();

            return response;

        }
    }
}

using LibraryManagementSystem.Application.Features.Book.Queries.Dtos;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Book.Queries.GetSIngleBook
{
    public class GetSingleBookQuery : IRequest<BookDto>
    {
        public int Id { get; set; }
    }
}

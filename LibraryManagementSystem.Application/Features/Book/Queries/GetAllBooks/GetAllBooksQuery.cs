using LibraryManagementSystem.Application.Features.Book.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Queries.GetAllBooks
{
    public record GetAllBooksQuery : IRequest<List<BookDto>>;
}

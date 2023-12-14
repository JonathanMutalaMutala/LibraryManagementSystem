using AutoMapper;
using LibraryManagementSystem.Application.Contracts.Persistence;
using LibraryManagementSystem.Application.Exceptions;
using LibraryManagementSystem.Application.Features.Book.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Queries.GetSIngleBook
{
    public class GetSingleBookQueryHandler : IRequestHandler<GetSingleBookQuery, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetSingleBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetSingleBookQuery request, CancellationToken cancellationToken)
        {
            var currentBook = await _bookRepository.GetByIdAsync(request.Id); 

            if(currentBook == null)
            {
                throw new NotFoundException(nameof(Book),request.Id);
            }

            var data = _mapper.Map<BookDto>(currentBook);

            return data;

        }
    }
}

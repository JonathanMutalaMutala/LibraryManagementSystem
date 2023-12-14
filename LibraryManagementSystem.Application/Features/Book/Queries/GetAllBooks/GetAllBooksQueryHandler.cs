using AutoMapper;
using LibraryManagementSystem.Application.Contracts.Persistence;
using LibraryManagementSystem.Application.Features.Book.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookDto>>
    {

        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public GetAllBooksQueryHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

       /// <summary>
       /// Methode permettant de recuperer tout les books 
       /// </summary>
       /// <param name="request"></param>
       /// <param name="cancellationToken"></param>
       /// <returns></returns>
        public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Domain.Entities.Book> books = await _bookRepository.GetAllAsync();

            List<BookDto> mappedData = _mapper.Map<List<BookDto>>(books);

            return mappedData;

        }
    }
}

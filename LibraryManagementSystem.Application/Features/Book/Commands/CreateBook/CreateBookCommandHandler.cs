using AutoMapper;
using LibraryManagementSystem.Application.Contracts.Persistence;
using LibraryManagementSystem.Application.Exceptions;
using LibraryManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        public readonly IMapper _mapper;
        public readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="request">Represente la request </param>
       /// <param name="cancellationToken"></param>
       /// <returns></returns>
       /// <exception cref="BadRequestException">Renvoie une bad Request si la request n'est pas valide </exception>
        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            // Faire la validatioin de la request qui est envoyé 

            var validator = new CreateBookCommandValidator(_bookRepository); 

            var ValidatorResult = await validator.ValidateAsync(request, cancellationToken);

            // Si ce n'est pas valid càd la request n'est pas valide 
            if (!ValidatorResult.IsValid)
            {
                throw new BadRequestException("Invalid Book", ValidatorResult); 
            }

            var newBook = _mapper.Map<Domain.Entities.Book>(request);



             await _bookRepository.CreateAsync(newBook);

            return newBook.Id;
        }
    }
}

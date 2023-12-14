using FluentValidation;
using LibraryManagementSystem.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public readonly IBookRepository bookRepository; 

        public CreateBookCommandValidator(IBookRepository bookRepository)
        {
            RuleFor(p => p.Author)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be less than 10 characters"); 

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be less than 50 characters");                
        }
    }
}

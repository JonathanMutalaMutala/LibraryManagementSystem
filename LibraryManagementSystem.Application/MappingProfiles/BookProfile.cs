using AutoMapper;
using LibraryManagementSystem.Application.Features.Book.Queries.GetAllBooks;
using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.MappingProfiles
{
    public  class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto,Book>().ReverseMap();
        }
        
    }
}

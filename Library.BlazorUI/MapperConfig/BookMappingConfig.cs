using AutoMapper;
using Library.BlazorUI.Models.BookModel;
using Library.BlazorUI.Services.Base;

namespace Library.BlazorUI.MapperConfig
{
    public class BookMappingConfig : Profile
    {
        public BookMappingConfig()
        {
            CreateMap<BookDto, BookVM>().ReverseMap();
        }


    }
}

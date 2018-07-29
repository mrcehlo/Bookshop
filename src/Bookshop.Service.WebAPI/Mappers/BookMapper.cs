using AutoMapper;
using Bookshop.Domain.Entities;
using Bookshop.Service.WebAPI.ViewModels;

namespace Bookshop.Service.WebAPI.Mappers
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<BookViewModel, Book>();
        }
    }
}

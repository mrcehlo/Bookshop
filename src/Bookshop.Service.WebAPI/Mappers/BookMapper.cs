using AutoMapper;
using Bookshop.Domain.Entities;
using Bookshop.Service.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

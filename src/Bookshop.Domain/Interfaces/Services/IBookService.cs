using Bookshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.Domain.Interfaces.Services
{
    public interface IBookService
    {
        void Add(Book _Book);
        Book Update(Book _Book);
        int Remove(Book _Book);
        IEnumerable<Book> GetAll();
        Book GetByParams(Book _Book);
    }
}

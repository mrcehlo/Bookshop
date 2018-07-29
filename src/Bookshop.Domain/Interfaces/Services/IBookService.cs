using Bookshop.Domain.Entities;
using System.Collections.Generic;

namespace Bookshop.Domain.Interfaces.Services
{
    public interface IBookService
    {
        void Add(Book book);
        Book Update(Book book);
        int Remove(Book book);
        IEnumerable<Book> GetAll();
        Book GetByParams(Book book);
    }
}

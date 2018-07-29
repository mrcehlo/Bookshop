using Bookshop.Domain.Entities;
using System.Collections.Generic;

namespace Bookshop.Domain.Interfaces.Repository
{
    public interface IBookRepository
    {
        void Add(Book book);
        Book Update(Book book);
        int Remove(Book book);
        IEnumerable<Book> GetAll();
        Book GetByParams(Book book);
    }
}

using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces.Repository;
using Bookshop.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Bookshop.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Add(Book book)
        {
            _bookRepository.Add(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll().OrderBy(c => c.Title);
        }

        public Book GetByParams(Book book)
        {
            return _bookRepository.GetByParams(book);
        }

        public int Remove(Book book)
        {
            return _bookRepository.Remove(book);
        }

        public Book Update(Book book)
        {
            return _bookRepository.Update(book);
        }
    }
}

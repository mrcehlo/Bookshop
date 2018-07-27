using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces.Repository;
using Bookshop.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookshop.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _BookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _BookRepository = bookRepository;
        }

        public void Add(Book _Book)
        {
            _BookRepository.Add(_Book);
        }

        public IEnumerable<Book> GetAll()
        {
            return _BookRepository.GetAll().OrderBy(c => c.Title);
        }

        public Book GetByParams(Book _Book)
        {
            return _BookRepository.GetByParams(_Book);
        }

        public int Remove(Book _Book)
        {
            return _BookRepository.Remove(_Book);
        }

        public Book Update(Book _Book)
        {
            return _BookRepository.Update(_Book);
        }
    }
}

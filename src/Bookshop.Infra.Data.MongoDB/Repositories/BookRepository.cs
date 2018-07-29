using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces.Repository;
using Bookshop.Infra.Data.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Bookshop.Infra.Data.MongoDB.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MongoDBContext<Book> _dbContext;

        public BookRepository(IDBContext<Book> dbContextBook)
        {
            _dbContext = (MongoDBContext<Book>)dbContextBook;
        }

        public void Add(Book book)
        {
            _dbContext.GetCollection().InsertOne(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return _dbContext.GetCollection().AsQueryable();
        }

        public Book GetByParams(Book book)
        {
            return (Book)_dbContext.GetCollection().Find(x =>
            (
                x.ISBN == book.ISBN || x.Title == book.Title || x.Publisher == book.Publisher ||
                x.Author == book.Author
            )).FirstOrDefault();
        }

        public int Remove(Book book)
        {
            var vResult = _dbContext.GetCollection().DeleteOne(x => (x.ISBN == book.ISBN));
            return vResult.IsAcknowledged ? (int)vResult.DeletedCount : -1;
        }

        public Book Update(Book book)
        {
            // in order to avoid updating mongodb Id property
            var savedBook = GetByParams(book);
            book.Id = savedBook.Id;

            _dbContext.GetCollection().ReplaceOne(x => x.ISBN == book.ISBN, book);
            return book;
        }
    }
}

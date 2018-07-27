using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces.Repository;
using Bookshop.Infra.Data.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.Infra.Data.MongoDB.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MongoDBContext<Book> _DBContext;

        public BookRepository(IDBContext<Book> _DBContextBook)
        {
            _DBContext = (MongoDBContext<Book>)_DBContextBook;
        }

        public void Add(Book _Book)
        {
            _DBContext.GetCollection().InsertOne(_Book);
        }

        public IEnumerable<Book> GetAll()
        {
            return _DBContext.GetCollection().AsQueryable();
        }

        public Book GetByParams(Book _Book)
        {
            return (Book)_DBContext.GetCollection().Find(x =>
            (
                x == _Book || x.Title == _Book.Title || x.Publisher == _Book.Publisher ||
                x.Author == _Book.Author || x.ISBN == _Book.ISBN
            )).FirstOrDefault();
        }

        public int Remove(Book _Book)
        {
            var vResult = _DBContext.GetCollection().DeleteOne(x => (x.ISBN == _Book.ISBN));
            return vResult.IsAcknowledged ? (int)vResult.DeletedCount : -1;
        }

        public Book Update(Book _Book)
        {
            _DBContext.GetCollection().ReplaceOne(x => x.Id == _Book.Id, _Book);
            return _Book;
        }
    }
}

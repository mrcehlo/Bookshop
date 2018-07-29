using Autofac;
using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces.Repository;
using Bookshop.Domain.Interfaces.Services;
using Bookshop.Domain.Services;
using Bookshop.Infra.Data.Interfaces;
using Bookshop.Infra.Data.MongoDB;
using Bookshop.Infra.Data.MongoDB.Repositories;

namespace Bookshop.CrossCutting.IoC
{
    public class CustomServiceModule : Module
    {
        public readonly string _connectionString;
        public readonly string _database;

        public CustomServiceModule(string connectionStringParam, string databaseParam)
        {
            _connectionString = connectionStringParam;
            _database = databaseParam;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MongoDBContext<Book>(_connectionString, _database))
                .As<IDBContext<Book>>().SingleInstance();
            
            builder.RegisterType<BookRepository>()
                .As<IBookRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookService>()
                .As<IBookService>()
                .InstancePerLifetimeScope();
        }
    }
}

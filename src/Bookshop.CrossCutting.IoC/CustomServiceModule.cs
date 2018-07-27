using Autofac;
using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces.Repository;
using Bookshop.Domain.Interfaces.Services;
using Bookshop.Domain.Services;
using Bookshop.Infra.Data.Interfaces;
using Bookshop.Infra.Data.MongoDB;
using Bookshop.Infra.Data.MongoDB.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.CrossCutting.IoC
{
    public class CustomServiceModule : Module
    {
        public readonly string _ConnectionString;
        public readonly string _Database;

        public CustomServiceModule(string ConnectionStringParam, string DatabaseParam)
        {
            _ConnectionString = ConnectionStringParam;
            _Database = DatabaseParam;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MongoDBContext<Book>(_ConnectionString, _Database))
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

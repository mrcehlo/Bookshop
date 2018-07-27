using Bookshop.Domain.Entities.Base;
using Bookshop.Infra.Data.Interfaces;
using Bookshop.Infra.Data.MongoDB.Mappings;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.Infra.Data.MongoDB
{
    public class MongoDBContext<TEntity> : IDBContext<TEntity> where TEntity : EntityBase
    {
        private MongoClient _MongoClient;
        private IMongoDatabase _Database;

        public MongoDBContext(string _ConnectionString, string _DatabaseName)
        {
            InitializeContext(_ConnectionString, _DatabaseName);
        }

        public IDBContext<TEntity> InitializeContext(string _ConnectionString, string _DatabaseName)
        {
            _MongoClient = new MongoClient(_ConnectionString);
            _Database = _MongoClient.GetDatabase(_DatabaseName);

            MongoDBMapping();

            return this;
        }

        public IMongoCollection<TEntity> GetCollection()
        {
            return _Database.GetCollection<TEntity>(typeof(TEntity).Name.ToString());
        }

        private void MongoDBMapping()
        {
            new BookMap();
        }
    }
}

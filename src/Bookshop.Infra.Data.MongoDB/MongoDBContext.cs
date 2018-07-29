using Bookshop.Domain.Entities.Base;
using Bookshop.Infra.Data.Interfaces;
using Bookshop.Infra.Data.MongoDB.Mappings;
using MongoDB.Driver;

namespace Bookshop.Infra.Data.MongoDB
{
    public class MongoDBContext<TEntity> : IDBContext<TEntity> where TEntity : EntityBase
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _database;

        public MongoDBContext(string connectionString, string databaseName)
        {
            InitializeContext(connectionString, databaseName);
        }

        public IDBContext<TEntity> InitializeContext(string connectionString, string databaseName)
        {
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(databaseName);

            MongoDBMapping();

            return this;
        }

        public IMongoCollection<TEntity> GetCollection()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name.ToString());
        }

        private void MongoDBMapping()
        {
            new BookMap();
        }
    }
}

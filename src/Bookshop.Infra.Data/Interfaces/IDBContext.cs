using Bookshop.Domain.Entities.Base;

namespace Bookshop.Infra.Data.Interfaces
{
    public interface IDBContext<TEntity> where TEntity : EntityBase
    {
        IDBContext<TEntity> InitializeContext(string _connectionString, string _databaseName);
    }
}

using Bookshop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.Infra.Data.Interfaces
{
    public interface IDBContext<TEntity> where TEntity : EntityBase
    {
        IDBContext<TEntity> InitializeContext(string _ConnectionString, string _DatabaseName);
    }
}

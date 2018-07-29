using Bookshop.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Bookshop.Infra.Data.MongoDB.Mappings
{
    public class BookMap
    {
        public BookMap()
        {
            BsonClassMap.RegisterClassMap<Book>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c.Id);
            });
        }
    }
}

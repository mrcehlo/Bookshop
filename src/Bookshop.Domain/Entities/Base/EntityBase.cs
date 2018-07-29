using Flunt.Notifications;
using System;

namespace Bookshop.Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {
        public Guid DefaultId { get; protected set; } = Guid.NewGuid();
    }
}

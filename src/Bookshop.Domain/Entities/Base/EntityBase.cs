using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {
        public Guid DefaultId { get; protected set; } = Guid.NewGuid();
    }
}

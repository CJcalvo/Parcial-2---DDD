using System;
using System.Collections.Generic;
using System.Text;
using static CapaDominio.Base.IEntity;

namespace CapaDominio.Base
{
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}

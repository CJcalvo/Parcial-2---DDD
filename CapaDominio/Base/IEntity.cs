using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio.Base
{
    interface IEntity
    {
        public interface IEntity<T>
        {
            T Id { get; set; }
        }
    }
}

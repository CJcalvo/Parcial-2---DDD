using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaInfraestructura.Base
{
    public class DbContextBase : DbContext, IDbContext
    {
        public DbContextBase(DbContextOptions options) : base(options)
        {

        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}

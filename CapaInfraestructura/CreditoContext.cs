using CapaDominio.Entities;
using CapaInfraestructura.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaInfraestructura
{
    public class CreditoContext : DbContextBase
    {
        public CreditoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Credito> Creditos { get; set; }
        public DbSet<Cuotas> Cuotas { get; set; }

    }
}

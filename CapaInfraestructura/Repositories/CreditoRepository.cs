using CapaInfraestructura.Base;
using System;
using System.Collections.Generic;
using System.Text;
using CapaDominio;
using CapaDominio.Entities;
using CapaDominio.Repositories;

namespace CapaInfraestructura.Repositories
{
    public class CreditoRepository : GenericRepository<Credito>, ICreditoRepository
    {
        public CreditoRepository(IDbContext context) : base(context)
        {

        }
    }


    
}

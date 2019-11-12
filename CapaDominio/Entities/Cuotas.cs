using CapaDominio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio.Entities
{
    public  class Cuotas : Entity<int>
    {
       
        public DateTime Fecha { get; set; }
        public decimal ValorCuota { get; set; }
        public int CreditoId { get; set; }

    
    }
}

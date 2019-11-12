using CapaDominio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio.Entities
{
    public class Credito : Entity<int>
    {

        public int NumeroDocumento { get; set; }
        public decimal ValorPrestamo { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroCuotas { get; set; }
        public List<Cuotas> Cuotas { get; set; }

        public Credito()
        {

        }

        public Credito(int numeroDocumento, decimal valorPrestamo, DateTime fecha, int numeroCuotas)
        {
            NumeroDocumento = numeroDocumento;
            ValorPrestamo = valorPrestamo;
            Fecha = fecha;
            NumeroCuotas = numeroCuotas;
            AddCuotas();
        }

        private List<Cuotas> Lista;
        public decimal cuota;
        public bool variable = false;

        public void AddCuotas()
        {
            Cuotas VarCuotas = new Cuotas();
            Lista = new List<Cuotas>();

            for (int i=0; i < NumeroCuotas ; i++)
            {
                VarCuotas.Fecha = Fecha.AddMonths(i);
                VarCuotas.ValorCuota = Calcularcuotas();
                Lista.Add(VarCuotas);
            }
        }


        public bool ConfirmarCantidadCuotas()
        {
            if (NumeroCuotas <= 0 || NumeroCuotas > 12)
            {
                variable = true;
            }

            return variable;
        }


        public decimal Calcularcuotas()
        {
            cuota = ValorPrestamo / NumeroCuotas;

            return cuota;
        }
    }
}

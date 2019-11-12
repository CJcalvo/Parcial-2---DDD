using CapaDominio.Contracts;
using CapaDominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaAplicacion
{
    public class RegistrarCredito
    {
        readonly IUnitOfWork _unitOfWork;

        public RegistrarCredito(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AgregarCreditoResponse Ejecutar(AgregarCreditoRequest request)
        {
            var credito = _unitOfWork.CreditoRepository.FindFirstOrDefault(t => t.NumeroDocumento == request.NumeroDocumento);
            if (credito == null)
            {
                credito = new Credito(request.NumeroDocumento,
                request.ValorPrestamo, request.Fecha, request.NumeroCuotas);
                if ( credito.ConfirmarCantidadCuotas() == false)
                {
                    _unitOfWork.CreditoRepository.Add(credito);
                    _unitOfWork.Commit();
                    return new AgregarCreditoResponse() { Mensaje = $"Credito generado" };
                }
                else
                {
                    return new AgregarCreditoResponse() { Mensaje = $"Cuotas Invalido" };
                }
            }
            else
            {
                return new AgregarCreditoResponse() { Mensaje = $"Invalido" };
            }
        }

    }

    public class AgregarCreditoRequest
    {
        public int NumeroDocumento { get; set; }
        public decimal ValorPrestamo { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroCuotas { get; set; }

    }
    public class AgregarCreditoResponse
    {
        public string Mensaje { get; set; }
    }

}


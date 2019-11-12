using CapaDominio.Entities;
using CapaInfraestructura;
using CapaInfraestructura.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CapaAplicacion.Test
{
    public class Tests
    {
        CreditoContext _context;
  
        

        [SetUp]
        public void Setup()
        {

            var optionsSqlServer = new DbContextOptionsBuilder<CreditoContext>()
             .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Parcial;Trusted_Connection=True;MultipleActiveResultSets=true")
             .Options;

            _context = new CreditoContext(optionsSqlServer);
        }

        

        [Test]
        public void CrearCreditotest()
        {
            var request = new AgregarCreditoRequest { NumeroDocumento  = 123456, ValorPrestamo = 10000000,
            Fecha = new DateTime(2019, 09, 09), NumeroCuotas = 12 };
            RegistrarCredito _service = new RegistrarCredito(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("Credito generado", response.Mensaje);
        }



        [Test]
        public void CrearCreditoNumeroCuotasInvalidosuperiortest()
        {
           var request = new AgregarCreditoRequest { NumeroDocumento  = 1234567, ValorPrestamo = 10000000,
            Fecha = new DateTime(2019, 09, 09), NumeroCuotas = 14 };
            RegistrarCredito _service = new RegistrarCredito(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("Cuotas Invalido", response.Mensaje);
        }

         [Test]
        public void CrearCreditoNumeroCuotasInvalidoinferiortest()
        {
           var request = new AgregarCreditoRequest { NumeroDocumento  = 1234567, ValorPrestamo = 10000000,
            Fecha = new DateTime(2019, 09, 09), NumeroCuotas = -2 };
            RegistrarCredito _service = new RegistrarCredito(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("Cuotas Invalido", response.Mensaje);
        }

    }
}
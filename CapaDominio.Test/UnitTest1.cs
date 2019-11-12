using CapaDominio.Entities;
using NUnit.Framework;
using System;

namespace CapaDominio.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

       
        [Test]
        public void RegistrarTest()
        {
            var cuenta = new Credito();
            cuenta.NumeroDocumento = 12345;
            cuenta.ValorPrestamo = 10000000;
            cuenta.Fecha = Convert.ToDateTime("2019 - 01 - 01");
            cuenta.NumeroCuotas = 10;

            Assert.AreEqual(cuenta.Calcularcuotas(), 1000000);
        }
    }
}
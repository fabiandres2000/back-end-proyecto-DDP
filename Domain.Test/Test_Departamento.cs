using Domain.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Domain.Test
{
    public class Test_Departamento
    {
        Departamento departamento;
        [SetUp]
        public void Setup()
        {
            departamento = new Departamento
            {
                IdDimension = "123",
                Nombre = "Cesar",
            };
        }

        [Test]
        public void RegistrarCorrectamente()
        {
            var mensaje = departamento.Guardar(departamento);
            Assert.AreEqual(mensaje, "se guardo todo cachon");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaCodigo()
        {

            departamento.IdDimension = null;
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => departamento.Guardar(departamento));
            Assert.AreEqual(ex.Message, "Llene todos los campos");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaDescripcion()
        {
            departamento.Nombre = null;
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => departamento.Guardar(departamento));
            Assert.AreEqual(ex.Message, "Llene todos los campos");
        }

        [Test]
        public void RegistrarIncorrectamenteSinInfo()
        {
            departamento.IdDimension = null;
            departamento.Nombre = null;
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => departamento.Guardar(departamento));
            Assert.AreEqual(ex.Message, "Llene todos los campos");
        }
    }
}
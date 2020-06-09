using Domain.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Domain.Test
{
    public class TestMunicipio
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
           
            Municipio Muni = new Municipio();
            Muni.IdDimension = "123";
            Muni.Nombre = "La Paz";
            Muni.Departamento = departamento;
            var mensaje = Muni.Guardar(Muni);
            Assert.AreEqual(mensaje, "se guardo todo cachon");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaCodigo()
        {

            Municipio Muni = new Municipio();
          
            Muni.Nombre = "La Paz";
            Muni.Departamento = departamento;

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Muni.Guardar(Muni));
            Assert.AreEqual(ex.Message, "Llene todos los campos");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaDescripcion()
        {
            Municipio Muni = new Municipio();
            Muni.IdDimension = "123";
          
            Muni.Departamento = departamento;

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Muni.Guardar(Muni));
            Assert.AreEqual(ex.Message, "Llene todos los campos");
        }

        [Test]
        public void RegistrarIncorrectamenteSinDepartamento()
        {
            departamento = null;
            Municipio Muni = new Municipio();
            Muni.IdDimension = "123";
            Muni.Nombre = "La Paz";
            Muni.Departamento = departamento;

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Muni.Guardar(Muni));
            Assert.AreEqual(ex.Message, "falta asociar a un departamento");
        }
    }
}
using Domain.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Domain.Test
{
    public class Test_Tratamiento
    {

        [SetUp]

        public void Setup()
        {

        }
        [Test]

        public void RegistrarCorrectamente()
        {
            Tratamiento Trata = new Tratamiento();
            Trata.Codigo = "123";
            Trata.Descripcion = "10 tabletas de acetaminofen";

            string ex =  Trata.Guardar(Trata);
            Assert.AreEqual(ex, "se guardo todo cachon");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaCodigo()
        {

            Tratamiento Trata = new Tratamiento();
         
            Trata.Descripcion = "10 tabletas de acetaminofen";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Trata.Guardar(Trata));
            Assert.AreEqual(ex.Message, "Llene todos los campos");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaDescripcion()
        {
            Tratamiento Trata = new Tratamiento();
            Trata.Codigo = "123";
           
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Trata.Guardar(Trata));
            Assert.AreEqual(ex.Message, "Llene todos los campos");
        }
    }
}

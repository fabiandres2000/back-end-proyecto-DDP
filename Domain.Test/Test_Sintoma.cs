using Domain.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Domain.Test
{
    public class Test_Sintoma
    {

        [SetUp]

        public void Setup()
        {

        }
        [Test]

        public void RegistrarCorrectamente()
        {
            Sintoma Sinto = new Sintoma();
            Sinto.Codigo = "123";
            Sinto.Descripcion = "fiebre";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Sinto.Guardar(Sinto));
            Assert.AreEqual(ex.Message, "se guardo todo cachon");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaCodigo()
        {
            Sintoma Sinto = new Sintoma();
           
            Sinto.Descripcion = "fiebre";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Sinto.Guardar(Sinto));
            Assert.AreEqual(ex.Message, "Llene todos los campos");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaDescripcion()
        {
            Sintoma Sinto = new Sintoma();
            Sinto.Codigo = "123";
        
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Sinto.Guardar(Sinto));
            Assert.AreEqual(ex.Message, "Llene todos los campos");
        }
    }
}
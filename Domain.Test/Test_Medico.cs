using Domain.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Domain.Test
{
    public class Test_Medico
    {

        [SetUp]

        public void Setup()
        {

        }
        [Test]

        public void RegistrarCorrectamente()
        {
            Medico medico = new Medico();
            medico.Apellidos = "quintero mendez";
            medico.CorreoElectronico = "grovveop@gmail.com";
            medico.Identificacion = "12345";
            medico.Nombres = "fabian andres";
            medico.Telefono = "3245654545";
            medico.Sexo = "M";
            medico.Edad = 34;
            medico.Direccion = "calle 5 a - 34 ";
            medico.Especializacion = "pulmonar";

            var respuesta = medico.Guardar(medico);
            Assert.AreEqual(respuesta, "Registrado correctamente");

        }

        [Test]
        public void RegistrarIncorrectamenteFaltaIdentificacion()
        {
            Medico medico = new Medico();
            medico.Apellidos = "quintero mendez";
            medico.CorreoElectronico = "grovveop@gmail.com";
         
            medico.Nombres = "fabian andres";
            medico.Telefono = "3245654545";
            medico.Sexo = "M";
            medico.Edad = 34;
            medico.Direccion = "calle 5 a - 34 ";
            medico.Especializacion = "pulmonar";

            var respuesta = medico.Guardar(medico);
            Assert.AreEqual(respuesta, "Digite los campos primordiales para su registro");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaNombreyApellido()
        {
         
            Medico medico = new Medico();
           
            medico.CorreoElectronico = "grovveop@gmail.com";
            medico.Identificacion = "12345";
            
            medico.Telefono = "3245654545";
            medico.Sexo = "M";
            medico.Edad = 34;
            medico.Direccion = "calle 5 a - 34 ";
            medico.Especializacion = "pulmonar";

            var respuesta = medico.Guardar(medico);
            Assert.AreEqual(respuesta, "Digite los campos primordiales para su registro");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaEspecializacion()
        {
            Medico medico = new Medico();
            medico.Apellidos = "quintero mendez";
            medico.CorreoElectronico = "grovveop@gmail.com";
            medico.Identificacion = "12345";
            medico.Nombres = "fabian andres";
            medico.Telefono = "3245654545";
            medico.Sexo = "M";
            medico.Edad = 34;
            medico.Direccion = "calle 5 a - 34 ";
           


            var respuesta = medico.Guardar(medico);
            Assert.AreEqual(respuesta, "Digite los campos primordiales para su registro");
        }
    }
}
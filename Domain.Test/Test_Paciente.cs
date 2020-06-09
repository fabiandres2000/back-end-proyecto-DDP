using Domain.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Domain.Test
{
    public class Test_Paciente
    {

        [SetUp]

        public void Setup()
        {
            
        }
        [Test]

        public void RegistrarCorrectamente()
        {
            Paciente Paci = new Paciente();
            Paci.Apellidos = "quintero mendez";
            Paci.CorreoElectronico = "grovveop@gmail.com";
            Paci.Identificacion = "12345";
            Paci.Nombres = "fabian andres";
            Paci.Telefono = "3245654545";
            Paci.Sexo = "M";
            Paci.Edad = 34;
            Paci.Direccion = "calle 5 a - 34 ";
            Paci.TipoAfiliacion = "Contributiva";

            var respuesta = Paci.Guardar(Paci);
            Assert.AreEqual(respuesta, "Registrado correctamente");

        }

        [Test]
        public void RegistrarIncorrectamenteFaltaIdentificacion()
        {
            Paciente Paci = new Paciente();
            Paci.Apellidos = "quintero mendez";
            Paci.CorreoElectronico = "grovveop@gmail.com";
           
            Paci.Nombres = "fabian andres";
            Paci.Telefono = "3245654545";
            Paci.Sexo = "M";
            Paci.Edad = 34;
            Paci.Direccion = "calle 5 a - 34 ";
            Paci.TipoAfiliacion = "Contributiva";

            var respuesta = Paci.Guardar(Paci);
            Assert.AreEqual(respuesta, "Digite los campos primordiales para su registro");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaNombreyApellido()
        {
            Paciente Paci = new Paciente();
           
            Paci.CorreoElectronico = "grovveop@gmail.com";
            Paci.Identificacion = "12345";
            
            Paci.Telefono = "3245654545";
            Paci.Sexo = "M";
            Paci.Edad = 34;
            Paci.Direccion = "calle 5 a - 34 ";
            Paci.TipoAfiliacion = "Contributiva";

            var respuesta = Paci.Guardar(Paci);
            Assert.AreEqual(respuesta, "Digite los campos primordiales para su registro");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaTipoAfiliacion()
        {
            Paciente Paci = new Paciente();
           
            Paci.Apellidos = "quintero mendez";
            Paci.CorreoElectronico = "grovveop@gmail.com";
            Paci.Identificacion = "12345";
            Paci.Nombres = "fabian andres";
            Paci.Telefono = "3245654545";
            Paci.Sexo = "M";
            Paci.Edad = 34;
            Paci.Direccion = "calle 5 a - 34 ";
           

            var respuesta = Paci.Guardar(Paci);
            Assert.AreEqual(respuesta, "Digite los campos primordiales para su registro");
        }
    }
}
using Domain.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Domain.Test
{
    public class Test_Administrador
    {
       
        [SetUp]
        public void Setup()
        {
        }
        [Test]

        public void RegistrarCorrectamente()
        {
            Administrador Admin = new Administrador();
            Admin.Apellidos = "quintero mendez";
            Admin.CorreoElectronico = "grovveop@gmail.com";
            Admin.Identificacion = "12345";
            Admin.Nombres = "fabian andres";
            Admin.Telefono = "3245654545";
            Admin.Sexo = "M";
            Admin.Edad = 34;
            Admin.Direccion = "calle 5 a - 34 ";

            var respuesta = Admin.Guardar(Admin);
            Assert.AreEqual(respuesta, "Registrado correctamente");
         
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaIdentificacion()
        {
            Administrador Admin = new Administrador();
            Admin.Apellidos = "quintero mendez";
            Admin.CorreoElectronico = "grovveop@gmail.com";
            Admin.Nombres = "fabian andres";
            Admin.Telefono = "3245654545";
            Admin.Sexo = "M";
            Admin.Edad = 34;
            Admin.Direccion = "calle 5 a - 34 ";

            var respuesta = Admin.Guardar(Admin);
            Assert.AreEqual(respuesta, "Digite los campos primordiales para su registro");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaNombreyApellido()
        {
            Administrador Admin = new Administrador();
            Admin.CorreoElectronico = "grovveop@gmail.com";
            Admin.Telefono = "3245654545";
            Admin.Sexo = "M";
            Admin.Edad = 34;
            Admin.Direccion = "calle 5 a - 34 ";
            Admin.Identificacion = "12345";
            var respuesta = Admin.Guardar(Admin);
            Assert.AreEqual(respuesta, "Digite los campos primordiales para su registro");
        }
    }
}

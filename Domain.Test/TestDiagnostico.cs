using Domain.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Domain.Test
{
    public class TestDiagnostico
    {
        Enfermedad enfermedad;
        Paciente paciente;
        Medico medico;
        [SetUp]
        public void Setup()
        {
            enfermedad = new Enfermedad
            {
                Codigo = "123",
                Nombre = "cancer-pulmonar",
                Gravedad = "grave",
                Tipo="cancer",
            };

            medico = new Medico
            {
                Apellidos = "quintero",
                Nombres = "cristian",
                Direccion = "valledupar",
                Edad = 18,
                Identificacion = "1234",
                Sexo = "M",
                Especializacion = "pulmonar"
            };

            paciente = new Paciente
            {
                Apellidos = "quintero",
                Nombres = "fabian",
                Direccion = "valledupar",
                Edad = 18,
                Identificacion = "123",
                Sexo = "M",
                Medico = medico
            };
           
        }

        [Test]
        public void RegistrarCorrectamente()
        {
            Diagnostico Diagn = new Diagnostico { Descripcion = "usted tiene 89 % de probabilidad de tener cancer pulmonar", Enfermedad = enfermedad, Medico = medico, Paciente = paciente, Estado = "pendiente" };
            var respuesta = Diagn.Guardar(Diagn);
            Assert.AreEqual(respuesta,"Se Registro correctamente");
        }

      

        [Test]
        public void RegistrarIncorrectamenteFaltaDescripcion()
        {
            Diagnostico Diagn = new Diagnostico {Enfermedad = enfermedad, Medico = medico, Paciente = paciente, Estado = "pendiente" };
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Diagn.Guardar(Diagn));
            Assert.AreEqual(ex.Message, "Complete todos los campos");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaMedico()
        {
            Diagnostico Diagn = new Diagnostico { Descripcion = "usted tiene 89 % de probabilidad de tener cancer pulmonar", Enfermedad = enfermedad, Paciente = paciente, Estado = "pendiente" };
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Diagn.Guardar(Diagn));
            Assert.AreEqual(ex.Message, "Complete todos los campos");
        }

        [Test]
        public void RegistrarIncorrectamenteFaltaPaciente()
        {
            Diagnostico Diagn = new Diagnostico { Descripcion = "usted tiene 89 % de probabilidad de tener cancer pulmonar", Enfermedad = enfermedad, Medico = medico ,Estado = "pendiente" };
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Diagn.Guardar(Diagn));
            Assert.AreEqual(ex.Message, "Complete todos los campos");
        }
        
    }
}
using Domain.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Domain.Test
{
    public class Tests
    {
        Paciente paciente;
        Medico medico;
        Enfermedad enfermedad2;
        Enfermedad enfermedad1;
        Enfermedad enfermedad;
        Sintoma sintoma;
        Sintoma sintoma1;
        Sintoma sintoma2;
        Sintoma sintoma3;
        Sintoma sintoma4;
        Sintoma sintoma5;
        Sintoma sintoma6;
        List<Enfermedad> enf;
        List<Sintoma> sin;
        List<Sintoma> sin2;
        List<Sintoma> sin3;

        [SetUp]
        public void Setup()
        {
            medico = new Medico() {
                Identificacion = "123",
                Nombres="fabian",
                Apellidos="quintero",
                CorreoElectronico = "34563@gmail.com",
                Direccion = "valledupar",
                Edad =23,
                Especializacion = "pulmonar",
                Estrato = 5,
                Sexo ="M",
                Telefono ="3123345666"
            };
            paciente = new Paciente()
            {
                Identificacion = "1234",
                Nombres = "fabian andres",
                Apellidos = "quintero mendez",
                CorreoElectronico = "232@gmail.com",
                Direccion = "valledupar cesar",
                Edad = 24,
                Medico = medico,
                Estrato = 2,
                Sexo = "M",
                Telefono = "3173345666"
            };

            sintoma = new Sintoma(){ 
            Codigo = "A1",
            Descripcion = "Tos"
            };

            sintoma1 = new Sintoma()
            {
                Codigo = "A2",
                Descripcion = "Fiebre"
            };

            sintoma2 = new Sintoma()
            {
                Codigo = "A3",
                Descripcion = "Secrecion Nasal"
            };

            sintoma3 = new Sintoma()
            {
                Codigo = "A4",
                Descripcion = "Tos Seca"
            };

            sintoma4 = new Sintoma()
            {
                Codigo = "A5",
                Descripcion = "Flemas"
            };

            sintoma5 = new Sintoma()
            {
                Codigo = "A6",
                Descripcion = "Dificultad Para Respirar"
            };

            sintoma6 = new Sintoma()
            {
                Codigo = "A7",
                Descripcion = "Dolor En El Pecho"
            };

            enfermedad = new Enfermedad()
            {
                Codigo = "A321",
                Nombre = "cancer-pulmonar",
                Sintomas = {sintoma,sintoma5,sintoma6},
                Gravedad= "grave"
            };
            

            enfermedad1 = new Enfermedad()
            {
                Codigo = "A322",
                Nombre = "Gripa",
                Sintomas = {sintoma,sintoma1,sintoma2,sintoma3},
                Gravedad = "grave"
            };

            enfermedad2 = new Enfermedad()
            {
                Codigo = "A323",
                Nombre = "coronavirus-F",
                Sintomas = { sintoma3,sintoma4,sintoma5},
                Gravedad = "muy grave"
            };

            enf = new List<Enfermedad>()
            {
                enfermedad,enfermedad1,enfermedad2
            };

            sin = new List<Sintoma>()
            {
                sintoma,sintoma1,sintoma2,sintoma3,sintoma4
            };

            sin2 = new List<Sintoma>()
            {
                sintoma,sintoma4,sintoma5,sintoma6
            };

            sin3 = new List<Sintoma>()
            {
                sintoma3,sintoma4,sintoma5,sintoma1
            };

        }
        [Test]

        public void DetectarEnfermedadGripa()
        {
            DetectarEnfermedadRequest rquest = new DetectarEnfermedadRequest();
            rquest.Paciente = paciente;
            rquest.Sintomas = sin;
            rquest.Enfermedades = enf;
            DetectarEnfermedadService service = new DetectarEnfermedadService();
            DetectarEnfermedadResponse responce = service.CalcularProbabilidad(rquest);
            Assert.AreEqual(responce.Enfermedad.Nombre, "Gripa");
        }

        [Test]

        public void DetectarEnfermedadCancer()
        {
            DetectarEnfermedadRequest rquest = new DetectarEnfermedadRequest();
            rquest.Paciente = paciente;
            rquest.Sintomas = sin2;
            rquest.Enfermedades = enf;
            DetectarEnfermedadService service = new DetectarEnfermedadService();
            DetectarEnfermedadResponse responce = service.CalcularProbabilidad(rquest);
            Assert.AreEqual(responce.Enfermedad.Nombre, "cancer-pulmonar");
        }

        [Test]
        public void DetectarEnfermedadCoronavirus()
        {
            DetectarEnfermedadRequest rquest = new DetectarEnfermedadRequest();
            rquest.Paciente = paciente;
            rquest.Sintomas = sin3;
            rquest.Enfermedades = enf;
            DetectarEnfermedadService service = new DetectarEnfermedadService();
            DetectarEnfermedadResponse responce = service.CalcularProbabilidad(rquest);
            Assert.AreEqual(responce.Enfermedad.Nombre, "coronavirus-F");
        }
    }
}
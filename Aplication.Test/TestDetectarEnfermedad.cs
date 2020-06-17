using NUnit.Framework;
using System.Collections;
using Domain.Entity;
using Domain.Service;
using Application.Services;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Aplication.Test
{
    public class TestDetectarEnfermedad
    {
        EpsContext _context;
        UnitOfWork unitOfWork;
        PacienteRequest paciente;
        MedicoRequest medico;
        SintomaRequest sintoma1;
        SintomaRequest sintoma2;
        SintomaRequest sintoma3;
        SintomaRequest sintoma4;
        SintomaRequest sintoma5;
        SintomaRequest sintoma6;
        SintomaRequest sintoma7;
        EnfermedadRequest enfermedad1;
        EnfermedadRequest enfermedad2;
        EnfermedadRequest enfermedad3;
        EnfermedadSintomaRequest enfermedad1sintoma1;
        EnfermedadSintomaRequest enfermedad1sintoma6;
        EnfermedadSintomaRequest enfermedad1sintoma7;
        EnfermedadSintomaRequest enfermedad2sintoma1;
        EnfermedadSintomaRequest enfermedad2sintoma2;
        EnfermedadSintomaRequest enfermedad2sintoma3;
        EnfermedadSintomaRequest enfermedad2sintoma4;
        EnfermedadSintomaRequest enfermedad3sintoma4;
        EnfermedadSintomaRequest enfermedad3sintoma5;
        EnfermedadSintomaRequest enfermedad3sintoma6;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EpsContext>().UseInMemoryDatabase("BDeps").Options;
            _context = new EpsContext(options);
            unitOfWork = new UnitOfWork(_context);

            Medico medico2 = new Medico()
            {
                Identificacion = "123",
                Nombres = "fabian",
                Apellidos = "quintero",
                CorreoElectronico = "34563@gmail.com",
                Direccion = "valledupar",
                Edad = 23,
                Especializacion = "pulmonar",
                Estrato = 5,
                Sexo = "M",
                Telefono = "3123345666",
            };

            paciente = new PacienteRequest()
            {
                Identificacion = "1234",
                Nombres = "fabian andres",
                Apellidos = "quintero mendez",
                CorreoElectronico = "232@gmail.com",
                Direccion = "valledupar cesar",
                Edad = 24,
                Estrato = 2,
                Sexo = "M",
                Telefono = "3173345666",
                TipoAfiliacion ="cotizante",
                Medico = medico2
                
            };
            new CrearPacienteService(unitOfWork).CrearPaciente(paciente);
            medico = new MedicoRequest()
            {
                Identificacion = "123",
                Nombres = "fabian",
                Apellidos = "quintero",
                CorreoElectronico = "34563@gmail.com",
                Direccion = "valledupar",
                Edad = 23,
                Especializacion = "pulmonar",
                Estrato = 5,
                Sexo = "M",
                Telefono = "3123345666",       
            };
            new CrearMedicoService(unitOfWork).CrearMedico(medico);
            sintoma1 = new SintomaRequest()
            {
                Codigo = "A1",
                Descripcion = "Tos"
            };

            sintoma2 = new SintomaRequest()
            {
                Codigo = "A2",
                Descripcion = "Fiebre"
            };

            sintoma3 = new SintomaRequest()
            {
                Codigo = "A3",
                Descripcion = "Secrecion Nasal"
            };

            sintoma4 = new SintomaRequest()
            {
                Codigo = "A4",
                Descripcion = "Tos Seca"
            };

            sintoma5 = new SintomaRequest()
            {
                Codigo = "A5",
                Descripcion = "Flemas"
            };

            sintoma6 = new SintomaRequest()
            {
                Codigo = "A6",
                Descripcion = "Dificultad Para Respirar"
            };

            sintoma7 = new SintomaRequest()
            {
                Codigo = "A7",
                Descripcion = "Dolor En El Pecho"
            };
            new CrearSintomaService(unitOfWork).CrearSitoma(sintoma1);
            new CrearSintomaService(unitOfWork).CrearSitoma(sintoma1);
            new CrearSintomaService(unitOfWork).CrearSitoma(sintoma2);
            new CrearSintomaService(unitOfWork).CrearSitoma(sintoma3);
            new CrearSintomaService(unitOfWork).CrearSitoma(sintoma4);
            new CrearSintomaService(unitOfWork).CrearSitoma(sintoma5);
            new CrearSintomaService(unitOfWork).CrearSitoma(sintoma6);
            new CrearSintomaService(unitOfWork).CrearSitoma(sintoma7);
            enfermedad1 = new EnfermedadRequest()
            {
                Codigo = "A321",
                Nombre = "cancer-pulmonar",
                Gravedad = "GRAVE",
                Tipo = "PULMONAR",
            };

            enfermedad2 = new EnfermedadRequest()
            {
                Codigo = "A322",
                Nombre = "gripa",
                Gravedad = "LEVE",
                Tipo = "PULMONAR",
            };
            enfermedad3 = new EnfermedadRequest()
            {
                Codigo = "A323",
                Nombre = "coronavirus-F",
                Gravedad = "GRAVE",
                Tipo = "PULMONAR",
            };
            new CrearEnfermedadService(unitOfWork).CrearEnfermedad(enfermedad1);
            new CrearEnfermedadService(unitOfWork).CrearEnfermedad(enfermedad2);
            new CrearEnfermedadService(unitOfWork).CrearEnfermedad(enfermedad3);
          
            enfermedad1sintoma1 = new EnfermedadSintomaRequest()
            {
                IDenfermedad = "A321",
                IDsintoma = "A1",
            };
            enfermedad1sintoma6 = new EnfermedadSintomaRequest()
            {
                IDenfermedad = "A321",
                IDsintoma = "A6",
            };
            enfermedad1sintoma7 = new EnfermedadSintomaRequest()
            {
                IDenfermedad = "A321",
                IDsintoma = "A7",
            };
            new CrearEnfermedadSintomaService(unitOfWork).CrearEnfermedadSitoma(enfermedad1sintoma1);
            new CrearEnfermedadSintomaService(unitOfWork).CrearEnfermedadSitoma(enfermedad1sintoma6);
            new CrearEnfermedadSintomaService(unitOfWork).CrearEnfermedadSitoma(enfermedad1sintoma7);

            enfermedad2sintoma1 = new EnfermedadSintomaRequest()
            {
                IDenfermedad = "A322",
                IDsintoma = "A1",
            };
            enfermedad2sintoma2 = new EnfermedadSintomaRequest()
            {
                IDenfermedad = "A322",
                IDsintoma = "A2",
            };
            enfermedad2sintoma3 = new EnfermedadSintomaRequest()
            {
                IDenfermedad = "A322",
                IDsintoma = "A3",
            };
            enfermedad2sintoma4 = new EnfermedadSintomaRequest()
            {
                IDenfermedad = "A322",
                IDsintoma = "A4",
            };

            new CrearEnfermedadSintomaService(unitOfWork).CrearEnfermedadSitoma(enfermedad2sintoma1);
            new CrearEnfermedadSintomaService(unitOfWork).CrearEnfermedadSitoma(enfermedad2sintoma2);
            new CrearEnfermedadSintomaService(unitOfWork).CrearEnfermedadSitoma(enfermedad2sintoma3);
            new CrearEnfermedadSintomaService(unitOfWork).CrearEnfermedadSitoma(enfermedad2sintoma4);


            enfermedad3sintoma4 = new EnfermedadSintomaRequest()
            {
                IDenfermedad = "A323",
                IDsintoma = "A4",
            };
            enfermedad3sintoma5 = new EnfermedadSintomaRequest()
            {
                IDenfermedad = "A323",
                IDsintoma = "A5",
            };
            enfermedad3sintoma6 = new EnfermedadSintomaRequest()
            {
                IDenfermedad = "A323",
                IDsintoma = "A6",
            };


            new CrearEnfermedadSintomaService(unitOfWork).CrearEnfermedadSitoma(enfermedad3sintoma4);
            new CrearEnfermedadSintomaService(unitOfWork).CrearEnfermedadSitoma(enfermedad3sintoma5);
            new CrearEnfermedadSintomaService(unitOfWork).CrearEnfermedadSitoma(enfermedad3sintoma6);
           
             
        }

        [Test]

        public void DetectarCancerPulmonar()
        {
            List<string> des = new List<string>() {"Tos","Dificultad Para Respirar","Dolor En El Pecho"};
            DetectarRequestapp2 request = new DetectarRequestapp2();
            request.Descripciones = des;
            request.IdPaciente = "1234";
            DetectarEnfermedadServiceApp service8 = new DetectarEnfermedadServiceApp (new UnitOfWork(_context));
            var responseapp = service8.detectar(request);
            Assert.AreEqual(responseapp.Message, "se le manda tratamiento");
            Console.WriteLine("su diagnostico es " + responseapp.MensajeDiagnostico);
        }

       
    }
}

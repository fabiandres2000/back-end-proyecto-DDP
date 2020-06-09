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
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EpsContext>().UseSqlServer("Server=.\\;Database=EpsBD;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            _context = new EpsContext(options);
            unitOfWork = new UnitOfWork(_context);
        }

        [Test]

        public void DetectarCancerPulmonar()
        {        
            DetectarRequestapp request = new DetectarRequestapp();
            request.IdPaciente = "1234";
            List<string> des = new List<string>() {"Tos","Dificultat Para Respirar","Dolor En El Pecho"};
            request.Descipciones = des;
            DetectarEnfermedadServiceApp service = new DetectarEnfermedadServiceApp(unitOfWork);
            DetectarResponseapp responseapp = new DetectarResponseapp();
            responseapp = service.detectar(request);
            Assert.AreEqual(responseapp.enfermedad.Nombre,"cancer-pulmonar");
            Console.WriteLine("su diagnostico es " + responseapp.diagnostico.Descripcion);
        }

        [Test]
        public void DetectarAGripa()
        {
            DetectarRequestapp request = new DetectarRequestapp();
            request.IdPaciente = "1234";
            List<string> des = new List<string>() { "Tos", "Fiebre", "Secrecion Nasal"};
            request.Descipciones = des;
            DetectarEnfermedadServiceApp service = new DetectarEnfermedadServiceApp(unitOfWork);
            DetectarResponseapp responseapp = new DetectarResponseapp();
            responseapp = service.detectar(request);
            Assert.AreEqual(responseapp.enfermedad.Nombre, "gripa");
            Console.WriteLine("su diagnostico es "+ responseapp.diagnostico.Descripcion);
        }

        [Test]
        public void DetectarNinguna()
        {
            DetectarRequestapp request = new DetectarRequestapp();
            request.IdPaciente = "1234";
            List<string> des = new List<string>() { "Fiebre", "nada", "nada" };
            request.Descipciones = des;
            DetectarEnfermedadServiceApp service = new DetectarEnfermedadServiceApp(unitOfWork);
            DetectarResponseapp responseapp = new DetectarResponseapp();
            responseapp = service.detectar(request);
            Assert.AreEqual(responseapp.Message, "sus sintomas no estan asociados a una enfermedad pulmonar");
        }
    }
}

using NUnit.Framework;
using System.Collections;
using Domain.Entity;
using Domain.Service;
using Application.Services;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Test
{
    public class TestEnfermedad
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

        [TestCaseSource("Creations")]
        public void Create(EnfermedadRequest request, string expected)
        {
            CrearEnfermedadService service = new CrearEnfermedadService(unitOfWork);
            var response = service.CrearEnfermedad(request);
            Assert.AreEqual(response.Message, expected);
        }

        private static IEnumerable Creations()
        {
            yield return new TestCaseData(
                new EnfermedadRequest
                {
                   Codigo = "A321",
                   Nombre = "prueba_jueves",
                   Gravedad = "GRAVE",
                   Tipo = "PULMONAR",
                },
                "Se Registro CorrectaMente"
            ).SetName("CreateOk");

       

            yield return new TestCaseData(
               new EnfermedadRequest
               {
                   Codigo = "A321",
                   Nombre = "cancer",
                   Gravedad = "GRAVE",
                   Tipo = "PULMONAR",
               },
               "Ya Existe Compa"
           ).SetName("CreateFail");

            yield return new TestCaseData(
                new EnfermedadRequest
                {
                    Codigo = "1235",
                   
                    Gravedad = "GRAVE",
                    Tipo = "PULMONAR",
                },
                "Llene todos los campos"
            ).SetName("CreateFailFaltaInfo");
        }
    }
}

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
    public class TestPaciente
    {
        EpsContext _context;
        UnitOfWork unitOfWork;
       

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EpsContext>().UseInMemoryDatabase("EpsBD").Options;
            _context = new EpsContext(options);
            unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("Creations")]
        public void Create(PacienteRequest request, string expected)
        {
            CrearPacienteService service = new CrearPacienteService(unitOfWork);
            var response = service.CrearPaciente(request);
            Assert.AreEqual(response.Message, expected);
        }

        private static IEnumerable Creations()
        {
            yield return new TestCaseData(            
                new PacienteRequest{
                Apellidos = "quintero",
                Nombres = "fabian",
                Direccion = "valledupar",
                Edad = 18,
                Identificacion = "123567",
                Sexo = "M",
                TipoAfiliacion = "subsidiado"
                },
                "Se Registro CorrectaMente"
            ).SetName("CreateOk");

            yield return new TestCaseData(
                new PacienteRequest
                {
                    Apellidos = "quintero",
                    Nombres = "fabian",
                    Direccion = "valledupar",
                    Edad = 18,
                    Identificacion = "123567",
                    Sexo = "M",
                    TipoAfiliacion = "subsidiado"
                },
                "El número de cedula ya exite"
            ).SetName("CreateFail");
        }
    }
}
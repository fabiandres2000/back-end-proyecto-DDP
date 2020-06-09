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
    public class Tests
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
        public void Create(SintomaRequest request, string expected)
        {
            CrearSintomaService service = new CrearSintomaService(unitOfWork);
            var response = service.CrearSitoma(request);
            Assert.AreEqual(response.Message, expected);
        }

        private static IEnumerable Creations()
        {
            yield return new TestCaseData(
                new SintomaRequest
                {
                    Codigo = "A31",
                    Descripcion = "Tos",
                },
                "Se Registro"
            ).SetName("CreateOk");
        }
    }
}
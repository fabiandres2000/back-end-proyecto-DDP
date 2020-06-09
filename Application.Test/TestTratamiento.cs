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
    public class TestTratamiento
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
        public void Create(TratamientoRequest request, string expected)
        {
            CrearTratamientoService service = new CrearTratamientoService(unitOfWork);
            var response = service.CrearSitoma(request);
            Assert.AreEqual(response.Message, expected);
        }

        private static IEnumerable Creations()
        {
            yield return new TestCaseData(
                new TratamientoRequest
                {
                    Codigo = "122",
                    Descripcion = "10 tabletas de acetaminofen",
                },
                "Se Registro"
            ).SetName("CreateOk");

            yield return new TestCaseData(
               new TratamientoRequest
               {
                   Codigo = "122",
                   Descripcion = "10 tabletas de acetaminofen",
               },
               "Ya Existe Compa"
           ).SetName("CreateFail");
        }


    }
}
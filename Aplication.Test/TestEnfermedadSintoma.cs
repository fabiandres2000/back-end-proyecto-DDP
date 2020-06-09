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
    public class TestEnfermedadSintoma
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
        /*
        [Test]
        public void Create1()
        {
            EnfermedadSintomaRequest request = new EnfermedadSintomaRequest();
            request.IDenfermedad = "A323";
            request.IDsintoma = "A4";
            CrearEnfermedadSintomaService service = new CrearEnfermedadSintomaService(unitOfWork);
            var response = service.CrearEnfermedadSitoma(request);
            Assert.AreEqual(response.Message, "Se Registro");
        }

        [Test]
        public void Create2()
        {
            EnfermedadSintomaRequest request = new EnfermedadSintomaRequest();
            request.IDenfermedad = "A323";
            request.IDsintoma = "A5";
            CrearEnfermedadSintomaService service = new CrearEnfermedadSintomaService(unitOfWork);
            var response = service.CrearEnfermedadSitoma(request);
            Assert.AreEqual(response.Message, "Se Registro");
        }

        [Test]
        public void Create3()
        {
            EnfermedadSintomaRequest request = new EnfermedadSintomaRequest();
            request.IDenfermedad = "A323";
            request.IDsintoma = "A6";
            CrearEnfermedadSintomaService service = new CrearEnfermedadSintomaService(unitOfWork);
            var response = service.CrearEnfermedadSitoma(request);
            Assert.AreEqual(response.Message, "Se Registro");
        }

       
     */

    }
}
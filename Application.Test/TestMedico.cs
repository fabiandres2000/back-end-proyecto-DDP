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
    public class TestMedico
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
        public void Create(MedicoRequest request, string expected)
        {
            CrearMedicoService service = new CrearMedicoService(unitOfWork);
            var response = service.CrearMedico(request);
            Assert.AreEqual(response.Message, expected);
        }

        private static IEnumerable Creations()
        {
            yield return new TestCaseData(
                new MedicoRequest
                {
                    Apellidos = "quintero mendez",
                    CorreoElectronico = "grovveop@gmail.com",
                    Identificacion = "123458",
                    Nombres = "fabian andres",
                    Telefono = "3245654545",
                    Sexo = "M",
                    Edad = 34,
                    Direccion = "calle 5 a - 34 ",
                    Especializacion = "pulmonar",
                },
                "Se Registro CorrectaMente"
            ).SetName("CreateOk");

            yield return new TestCaseData(
                new MedicoRequest
                {
                    Apellidos = "quintero mendez",
                    CorreoElectronico = "grovveop@gmail.com",
                    Identificacion = "12345",
                    Nombres = "fabian andres",
                    Telefono = "3245654545",
                    Sexo = "M",
                    Edad = 34,
                    Direccion = "calle 5 a - 34 ",
                    Especializacion = "pulmonar",
                },
                "El número de cedula ya exite"
            ).SetName("CreateFail");

            yield return new TestCaseData(
             new MedicoRequest
             {
                 Apellidos = "quintero mendez",
                 CorreoElectronico = "grovveop@gmail.com",
               
                 Nombres = "fabian andres",
                 Telefono = "3245654545",
                 Sexo = "M",
                 Edad = 34,
                 Direccion = "calle 5 a - 34 ",
                 Especializacion = "pulmonar",
             },
             "Digite los campos primordiales para su registro"
         ).SetName("CreateFailFaltaId");
        }
    }
}

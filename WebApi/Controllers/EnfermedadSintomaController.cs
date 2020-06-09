using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.Contracts;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermedadSintomaController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        private EpsContext db;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public EnfermedadSintomaController(IUnitOfWork utrabajo, EpsContext context)
        {
            _unitOfWork = utrabajo;
            db = context;

        }

        [HttpPost("[action]")]
        public ActionResult<EnfermedadSintomaResponse> Post(EnfermedadSintomaRequest request)
        {
            CrearEnfermedadSintomaService _service = new CrearEnfermedadSintomaService(_unitOfWork);
            EnfermedadSintomaResponse response = _service.CrearEnfermedadSitoma(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public IEnumerable<ConsultarEnfermedadSintomaResponse> EnfermedadesSintomas()
        {
            ConsultarEnfermedadSintomaService servicio = new ConsultarEnfermedadSintomaService(_unitOfWork);
            List<ConsultarEnfermedadSintomaResponse> response = servicio.Consultar();

            return response;

        }

        [HttpDelete ("[action]")]
        public ActionResult<EliminarResponse> EliminarEnfermedadSintoma(int id)
        {
            EliminarServices _service = new EliminarServices(_unitOfWork);
            EliminarResponse response = _service.ElminarEnfermedadSintoma(id);
            return Ok(response);
        }

    }
}
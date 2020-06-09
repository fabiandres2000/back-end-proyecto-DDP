using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.Contracts;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermedadTratamientoController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        private EpsContext db;
        //Se Recomienda solo dejar la Unidad de Trabajo
        public EnfermedadTratamientoController(IUnitOfWork unitOfWork, EpsContext context)
        {
            _unitOfWork = unitOfWork;
            db = context;
        }

        [HttpPost("[action]")]
        public ActionResult<EnfermedadTratamientoResponse> AsociarEnfermedadTratamiento(EnfermedadTratamientoRequest request)
        {
            CrearEnfermedadTratamientoService _service = new CrearEnfermedadTratamientoService(_unitOfWork);
            EnfermedadTratamientoResponse response = _service.CrearEnfermedadTratamiento(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public IEnumerable<ConsultarEnfermedadTratamientoResponse> EnfermedadesTratamientos()
        {
            ConsultarEnfermedadTratamientoService servicio = new ConsultarEnfermedadTratamientoService(_unitOfWork);
            List<ConsultarEnfermedadTratamientoResponse> response = servicio.ConsultarEnfermedadTratamiento();
            return response;
        }

        [HttpDelete("[action]")]
        public ActionResult<EliminarResponse> EliminarEnfermedadTratamiento(int id)
        {
            EliminarServices _service = new EliminarServices(_unitOfWork);
            EliminarResponse response = _service.ElminarEnfermedadTratamiento(id);
            return Ok(response);
        }
    }
}
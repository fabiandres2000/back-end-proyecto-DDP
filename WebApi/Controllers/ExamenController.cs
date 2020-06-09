using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using WebApi.Models;
using Domain.Entity;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
      

        //Se Recomienda solo dejar la Unidad de Trabajo
        public ExamenController(IUnitOfWork utrabajo, EpsContext context)
        {
            _unitOfWork = utrabajo;
        }

        [HttpPost("[action]")]
        public ActionResult<ExamenResponse> Post(ExamenRequest request)
        {
            CrearExamenService _service = new CrearExamenService(_unitOfWork);
            ExamenResponse response = _service.CrearExamen(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public IEnumerable<Examen> Examenes()
        {
            ConsultarExamenService servicio = new ConsultarExamenService(_unitOfWork);
            List<Examen> Lista = servicio.GetAll();
            return Lista;
        }

        [HttpDelete("[action]")]
        public ActionResult<PacienteResponse> EliminarExamen(int Id)
        {
            EliminarServices _service = new EliminarServices(_unitOfWork);
            EliminarResponse response = _service.EliminarExamen(Id);
            return Ok(response);
        }

    }
}
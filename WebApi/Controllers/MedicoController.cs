using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.Contracts;
using Domain.Entity;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        private EpsContext db;


     
        public MedicoController(IUnitOfWork unitOfWork, EpsContext context)
        {
            _unitOfWork = unitOfWork;
            db = context;

        }

        [HttpPost("[action]")]
        public ActionResult<MedicoResponse> RegistrarMedico(MedicoRequest request)
        {
            CrearMedicoService _service = new CrearMedicoService(_unitOfWork);
            MedicoResponse response = _service.CrearMedico(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public IEnumerable<Medico> Medicos()
        {
            ConsultarMedicoService servicio = new ConsultarMedicoService(_unitOfWork);
            List<Medico> Lista = servicio.GetAll();
            return Lista;
            
        }


        [HttpDelete("[action]")]
        public ActionResult<PacienteResponse> EliminarMedico(string identificacion)
        {
            EliminarServices _service = new EliminarServices(_unitOfWork);
            EliminarResponse response = _service.DeleteMedico(identificacion);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public ActionResult<MedicoResponse> ActualizarMedico([FromBody]MedicoRequest request)
        {
            ActualizarService _service = new ActualizarService(_unitOfWork);
            MedicoResponse response = _service.ActualizarMedico(request);
            return Ok(response);
        }
    }
}
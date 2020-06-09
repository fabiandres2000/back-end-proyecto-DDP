using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Infrastructure;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        private EpsContext db;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public PacienteController(IUnitOfWork utrabajo, EpsContext context)
        {
            _unitOfWork = utrabajo;
            db = context;

        }

        [HttpPost("[action]")]
        public ActionResult<PacienteResponse> Post([FromBody]PacienteRequest request)
        {
            CrearPacienteService _service = new CrearPacienteService(_unitOfWork);
            PacienteResponse response = _service.CrearPaciente(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public ActionResult<AsignarMedicoResponse> AsignarMedico([FromBody]AsignarMedicoRequest request)
        {
            AsignarMedicoService _service = new AsignarMedicoService(_unitOfWork);
            AsignarMedicoResponse response = _service.Asignar(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public ActionResult<PacienteResponse> ActualizarPaciente([FromBody]PacienteRequest request)
        {
            ActualizarService _service = new ActualizarService(_unitOfWork);
            PacienteResponse response = _service.ActualizarPaciente(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public IEnumerable<PacienteViewModels> Pacientes()
        {
            List<PacienteViewModels> list = null;
            list = (from d in db.Paciente
                    select new PacienteViewModels
                    {
                        Identificacion = d.Identificacion,
                        Nombres = d.Nombres,
                        Apellidos = d.Apellidos,
                        TipoAfiliacion = d.TipoAfiliacion,
                        Telefono = d.Telefono,
                        CorreoElectronico = d.CorreoElectronico,
                        Direccion = d.Direccion,
                        Edad = d.Edad,
                        Estrato = d.Estrato,
                        Sexo = d.Sexo,
                        Medico = d.Medico
                    }).ToList();
            return list;
        }

        [HttpDelete("[action]")]
        public ActionResult<PacienteResponse> EliminarPaciente(string Identificacion)
        {
            EliminarServices _service = new EliminarServices(_unitOfWork);
            EliminarResponse response = _service.DeletePaciente(Identificacion);
            return Ok(response);
        }
    }
}
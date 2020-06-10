using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.Contracts;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticoController : ControllerBase
    {

        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public DiagnosticoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("[action]")]
        public ActionResult<DiagnosticoResponse> GuardarDiagnostico([FromBody]DiagnosticoRequest request)
        {
            CrearDiagnosticoService _service = new CrearDiagnosticoService(_unitOfWork);
            DiagnosticoResponse response = _service.CrearDiagnostico(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Diagnostico>> GetAll()
        {
            var res = new ConsultarDiagnosticoService(_unitOfWork);
            return res.GetAll();
        }


        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Diagnostico>> GetIdPaciente(string IdPaciente)
        {
            var res = new ConsultarDiagnosticoService(_unitOfWork);
            return res.GetIdPaciente(IdPaciente);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Diagnostico>> GetIdMedico(string IdMedico)
        {
            var res = new ConsultarDiagnosticoService(_unitOfWork);
            return res.GetIdMedico(IdMedico);
        }

        [HttpPut("[action]")]
        public ActionResult<CompletarDiagnosticoResponse> CompletarDiagnostico([FromBody]CompletarDiagnosticoRequest request)
        {
            CompletarDiagnosticoService completar = new CompletarDiagnosticoService(_unitOfWork);
            CompletarDiagnosticoResponse response = completar.Completar(request);
            return Ok(response);
        }

    }
}
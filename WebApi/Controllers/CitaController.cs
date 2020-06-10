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
    public class CitaController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public CitaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("[action]")]
        public ActionResult<CitaResponse> ApartarCita(CitaRequest request)
        {
            CrearCitaService _service = new CrearCitaService(_unitOfWork);
            CitaResponse response = _service.CrearCita(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Cita>> GetAll()
        {
            var res = new ConsultarCitaService(_unitOfWork);
            return res.GetAll();
        }


        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Cita>> GetIdPaciente(string IdPaciente)
        {
            var res = new ConsultarCitaService(_unitOfWork);
            return res.GetIdPaciente(IdPaciente);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Cita>> GetIdMedico(string IdMedico)
        {
            var res = new ConsultarCitaService(_unitOfWork);
            return res.GetIdMedico(IdMedico);
        }


        [HttpDelete("[action]")]
        public ActionResult<EnfermedadResponse> EliminarCita(int id)
        {
            EliminarServices _service = new EliminarServices(_unitOfWork);
            EliminarResponse response = _service.EliminarCita(id);
            return Ok(response);
        }
    }
}
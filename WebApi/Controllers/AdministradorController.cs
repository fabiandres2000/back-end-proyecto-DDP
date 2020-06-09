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

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        private EpsContext db;


        public AdministradorController(IUnitOfWork unitOfWork, EpsContext context)
        {
            _unitOfWork = unitOfWork;
            db = context;

        }

        [HttpPost("[action]")]
        public ActionResult<CrearAdninistradorResponce> RegistrarAdministrador(CrearAdninistradorRequest request)
        {
            CrearAdministradorService _service =  new CrearAdministradorService(_unitOfWork);    
            CrearAdninistradorResponce response = _service.CrearAdministrador(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public IEnumerable<Administrador> Administradores()
        {
            ConsultarAdministradorService servicio = new ConsultarAdministradorService(_unitOfWork);
            List<Administrador> Lista = servicio.GetAll();
            return Lista;

        }

        [HttpDelete("[action]")]
        public ActionResult<PacienteResponse> EliminarAdministrador(string identificacion)
        {
            EliminarServices _service = new EliminarServices(_unitOfWork);
            EliminarResponse response = _service.DeleteAdministrador(identificacion);
            return Ok(response);
        }
    }
}
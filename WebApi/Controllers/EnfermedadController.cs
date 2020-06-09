using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Services;
using Domain.Contracts;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermedadController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        private EpsContext db;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public EnfermedadController(IUnitOfWork utrabajo, EpsContext context)
        {
            _unitOfWork = utrabajo;
            db = context;

        }

        [HttpPost("[action]")]
        public ActionResult<EnfermedadResponse> Post([FromBody]EnfermedadRequest request)
        {
            CrearEnfermedadService _service = new CrearEnfermedadService(_unitOfWork);
            EnfermedadResponse response = _service.CrearEnfermedad(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public ActionResult<EnfermedadResponse> EliminarEnfermedad(string Codigo)
        {
            EliminarServices _service = new EliminarServices(_unitOfWork);
            EliminarResponse response = _service.DeleteEnfermedad(Codigo);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public IEnumerable<EnfermedadViewModels> Enfermedades()
        {
            List<EnfermedadViewModels> list = null;
            list = (from d in db.Enfermedad
                    select new EnfermedadViewModels
                    {
                        Codigo = d.Codigo,
                        Nombre = d.Nombre,
                        Gravedad = d.Gravedad,
                        Tipo = d.Tipo
                    }).ToList();
            return list;
        }


    }
}
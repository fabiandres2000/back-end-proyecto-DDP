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

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SintomaController : ControllerBase
    {

        readonly IUnitOfWork _unitOfWork;
        private EpsContext db;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public SintomaController(IUnitOfWork utrabajo, EpsContext context)
        {
            _unitOfWork = utrabajo;
            db = context;

        }

        [HttpGet("[action]")]
        public IEnumerable<SintomaViewModels> Sintomas()
        {
            List<SintomaViewModels> list = null;
            list = (from d in db.Sintoma
                    select new SintomaViewModels
                    {
                        Codigo = d.Codigo,
                        Descripcion = d.Descripcion,
                    }).ToList();
            return list;
        }

        [HttpPost("[action]")]
        public ActionResult<SintomaResponse> Post(SintomaRequest request)
        {
            CrearSintomaService _service = new CrearSintomaService(_unitOfWork);
            SintomaResponse response = _service.CrearSitoma(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public ActionResult<PacienteResponse> EliminarSintoma(string Codigo)
        {
            EliminarServices _service = new EliminarServices(_unitOfWork);
            EliminarResponse response = _service.DeleteSintoma(Codigo);
            return Ok(response);
        }
    }
}
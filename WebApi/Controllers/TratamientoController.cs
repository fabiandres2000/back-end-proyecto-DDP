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
    public class TratamientoController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        private EpsContext db;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public TratamientoController(IUnitOfWork utrabajo, EpsContext context)
        {
            _unitOfWork = utrabajo;
            db = context;

        }

        [HttpPost("[action]")]
        public ActionResult<TratamientoResponse> Post(TratamientoRequest request)
        {
            CrearTratamientoService _service = new CrearTratamientoService(_unitOfWork);
            TratamientoResponse response = _service.CrearTratamiento(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public IEnumerable<TratamientoViewModels> Tratamientos()
        {
            List<TratamientoViewModels> list = null;
            list = (from d in db.Tratamiento
                    select new TratamientoViewModels
                    {
                        Codigo = d.Codigo,
                        Descripcion = d.Descripcion,
                    }).ToList();
            return list;
        }

        [HttpDelete("[action]")]
        public ActionResult<PacienteResponse> EliminarTratamiento(string Codigo)
        {
            EliminarServices _service = new EliminarServices(_unitOfWork);
            EliminarResponse response = _service.DeleteTratamiento(Codigo);
            return Ok(response);
        }
    }
}
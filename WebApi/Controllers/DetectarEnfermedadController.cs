using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetectarEnfermedadController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public DetectarEnfermedadController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("[action]")]
        public ActionResult<DetectarResponseapp> Detectar([FromBody]DetectarRequestapp2 request)
        {
            DetectarEnfermedadServiceApp _service = new DetectarEnfermedadServiceApp(_unitOfWork);
            DetectarResponseapp response = _service.detectar(request);
            return Ok(response);
        }
    }
}
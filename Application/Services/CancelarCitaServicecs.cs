using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Application.Services
{
    public class CancelarCitaServicecs
    {
        readonly IUnitOfWork _unitOfWork;
        public CancelarCitaServicecs(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public CancelarCitaResponse CancelarCita(int id)
        {

         
            Cita cita = _unitOfWork.CitaRepository.FindFirstOrDefault(C => C.Id == id);

            if (cita.Estado == "atendido")
            {
                return new CancelarCitaResponse() { Message = $"Esta cita ya no se puede cancelar" };
            }

            if (cita.Estado == "cancelado")
            {
                return new CancelarCitaResponse() { Message = $"Esta cita ya ha sido cancelada" };
            }

            cita.Estado = "cancelado";
            _unitOfWork.CitaRepository.Edit(cita);
            _unitOfWork.Commit();
            return new CancelarCitaResponse() { Message = $"Esta cita se ha cancelado satisfactoriamente" };
        }
    }

   public class CancelarCitaRequest
    {
        public int Id { get; set; }
    }
    public class CancelarCitaResponse
    {
        public string Message { get; set; }
    }
}

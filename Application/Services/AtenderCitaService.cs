using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Application.Services
{
    public class AtenderCitaService
    {
        readonly IUnitOfWork _unitOfWork;
        public AtenderCitaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public AtenderCitaResponse AtenderCita(int id)
        {


            Cita cita = _unitOfWork.CitaRepository.FindFirstOrDefault(C => C.Id == id);

            if (cita.Estado == "atendido")
            {
                return new AtenderCitaResponse() { Message = $"Esta cita ya no se puede atenter" };
            }

            if (cita.Estado == "cancelado")
            {
                return new AtenderCitaResponse() { Message = $"Esta cita  ha sido cancelada" };
            }

            cita.Estado = "atendida";
            _unitOfWork.CitaRepository.Edit(cita);
            _unitOfWork.Commit();
            return new AtenderCitaResponse() { Message = $"Esta cita se ha atendido satisfactoriamente" };
        }
    }


    public class AtenderCitaResponse
    {
        public string Message { get; set; }
    }
}

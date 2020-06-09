using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class ConsultarHistorialCitaService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarHistorialCitaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public List<Cita> Get(int id)
        {
            var cita = _unitOfWork.CitaRepository.FindBy(H => H.Paciente.Id == id).ToList();

            return cita;
        }
    }
}

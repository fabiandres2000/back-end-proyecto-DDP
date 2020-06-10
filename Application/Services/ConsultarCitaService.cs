using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class ConsultarCitaService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarCitaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public List<Cita> GetAll()
        {
            var res = _unitOfWork.CitaRepository.FindBy(includeProperties: "Paciente,Medico");
            return res.ToList();
        }


        public List<Cita> GetIdPaciente(string Identificacion)
        {
            var ConsultarId = _unitOfWork.CitaRepository.FindBy(D => D.Paciente.Identificacion == Identificacion, includeProperties: "Paciente,Medico");
            return ConsultarId.ToList();
        }


        public List<Cita> GetIdMedico(string Identificacion)
        {
            var ConsultarId = _unitOfWork.CitaRepository.FindBy(D => D.Medico.Identificacion == Identificacion, includeProperties: "Paciente,Medico");
            return ConsultarId.ToList();
        }
    }
}

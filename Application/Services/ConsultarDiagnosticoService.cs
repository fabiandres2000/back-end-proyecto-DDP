using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class ConsultarDiagnosticoService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarDiagnosticoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public List<Diagnostico> GetAll()
        {
            var res = _unitOfWork.DiagnosticoRepository.FindBy(includeProperties:"Paciente,Enfermedad,Medico,Tratamiento,Examen");
            return res.ToList();
        }


        public List<Diagnostico> GetIdPaciente(string Identificacion)
        {
            var ConsultarId = _unitOfWork.DiagnosticoRepository.FindBy(D => D.Paciente.Identificacion == Identificacion, includeProperties: "Paciente,Enfermedad,Tratamiento,Examen");
            return ConsultarId.ToList();
        }

      
        public List<Diagnostico> GetIdMedico(string Identificacion)
        {
            var ConsultarId = _unitOfWork.DiagnosticoRepository.FindBy(D => D.Medico.Identificacion == Identificacion, includeProperties: "Paciente,Enfermedad,Medico,Tratamiento,Examen");
            return ConsultarId.ToList();
        }
    }
}

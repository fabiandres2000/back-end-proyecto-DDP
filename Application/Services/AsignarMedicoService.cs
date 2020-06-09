using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class AsignarMedicoService
    {
        readonly IUnitOfWork _unitOfWork;


        public AsignarMedicoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public AsignarMedicoResponse Asignar(AsignarMedicoRequest request)
        {
            var Paciente = _unitOfWork.IPacienteRepository.FindFirstOrDefault(P=>P.Identificacion==request.IdPaciente);
            var Medico = _unitOfWork.IMedicoRepository.FindFirstOrDefault(P=>P.Identificacion==request.IdMedico);

          
            if (Paciente!=null && Medico != null)
            {
                Paciente.Medico = Medico;
                _unitOfWork.IPacienteRepository.Edit(Paciente);
                _unitOfWork.Commit();
                return new AsignarMedicoResponse() { Message = $"Se le asocio correctamente al Dr. {Medico.Nombres} {Medico.Apellidos}"};
            }
            else
            {
                return new AsignarMedicoResponse() { Message = $"Verifique los datos" };

            }


        }


    }

    public class AsignarMedicoRequest
    {
        public string IdMedico { get; set; }
        public string IdPaciente { get; set; }
    }
    public class AsignarMedicoResponse
    {
        public string Message { get; set; }
    }


}

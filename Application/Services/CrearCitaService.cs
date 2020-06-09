using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class CrearCitaService
    {
        readonly IUnitOfWork _unitOfWork;


        public CrearCitaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public CitaResponse CrearCita(CitaRequest request)
        {
            Cita cita = _unitOfWork.CitaRepository.FindFirstOrDefault(C => C.Id == request.Id);
            request.Medico = _unitOfWork.IMedicoRepository.FindFirstOrDefault(P => P.Identificacion == request.IdMedico);
            var Medico= _unitOfWork.IMedicoRepository.FindFirstOrDefault(P => P.Identificacion == request.IdMedico);
            request.Paciente= _unitOfWork.IPacienteRepository.FindFirstOrDefault(P => P.Identificacion == request.IdEnfermedad);
            var Disponibilidad = request.Medico.Verificar_disponibilidad(request.Fecha,request.Minuto,request.Hora);
            var fecha = _unitOfWork.CitaRepository.FindBy(C => C.Fecha == request.Fecha && C.Hora == request.Hora && C.Minuto == request.Minuto).ToList();
            if (cita==null && fecha==null && Disponibilidad)
            {
                Cita NuevaCita = new Cita();
                NuevaCita.Medico = request.Medico;
                NuevaCita.Paciente = request.Paciente;
                NuevaCita.Fecha = request.Fecha;
                NuevaCita.Hora = request.Hora;
                NuevaCita.Minuto = request.Minuto;
                Medico.Citas.Add(NuevaCita);
                _unitOfWork.CitaRepository.Add(NuevaCita);
                _unitOfWork.Commit();
                return new CitaResponse() { Message = $"Se Registro su cita con el medico : {request.Medico.Apellidos} {request.Medico.Nombres}" };

            }
            else
            {
                return new CitaResponse() { Message = $"No  Registro Compa" };
            }
        }


    }

    public class CitaRequest
    {
        public string IdMedico{ get; set; }
        public string IdEnfermedad { get; set; }
        public int Id { get; set; }
        public string Fecha { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }

        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }

        public CitaRequest( Medico medico , Paciente paciente)
        {
            this.Medico = medico;
            this.Paciente = paciente;
        }

    }

    public class CitaResponse
    {
        public string Message { get; set; }
    }
}

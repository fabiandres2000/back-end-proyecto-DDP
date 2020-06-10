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
            request.Paciente= _unitOfWork.IPacienteRepository.FindFirstOrDefault(P => P.Identificacion == request.Idpaciente);
            request.Medico = _unitOfWork.IMedicoRepository.FindFirstOrDefault(P => P.Identificacion == request.Paciente.Medico.Identificacion);
            
            if (request.Medico == null)
            {
                return new CitaResponse() { Message = $"Aun no se le ha asignado un medico, vaya a la opcion --> asociar medico" };
            }

            Cita cita = _unitOfWork.CitaRepository.FindFirstOrDefault(C => C.Fecha == request.Fecha && C.Hora == request.Hora && C.Minuto == request.Minuto && C.Medico == request.Medico);

            if (cita != null)
            {
                return new CitaResponse() { Message = $"Esta hora ya esta ocupada, seleccione otra" };
            }
            
            Cita NuevaCita = new Cita();
            NuevaCita.Medico = request.Medico;
            NuevaCita.Paciente = request.Paciente;
            NuevaCita.Fecha = request.Fecha;
            NuevaCita.Hora = request.Hora;
            NuevaCita.Minuto = request.Minuto;
            _unitOfWork.CitaRepository.Add(NuevaCita);
            _unitOfWork.Commit();
            return new CitaResponse() { Message = $"Se Registro su cita con el medico : {request.Medico.Apellidos} {request.Medico.Nombres}" };

          
        }


    }

    public class CitaRequest
    {
        public string Idpaciente { get; set; }
        public string Fecha { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }


    }

    public class CitaResponse
    {
        public string Message { get; set; }
    }
}

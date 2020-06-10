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

            var paciente_prueba = _unitOfWork.IPacienteRepository.FindBy(p => p.Identificacion == request.Idpaciente, includeProperties: "Medico").ToList();
            var  Paciente= _unitOfWork.IPacienteRepository.FindFirstOrDefault(P => P.Identificacion==request.Idpaciente);
            var Medico = Paciente.Medico;

            if (Medico == null)
            {
                return new CitaResponse() { Message = $"Aun no se le ha asignado un medico, vaya a la opcion --> asociar medico" };
            }

            Cita cita = _unitOfWork.CitaRepository.FindFirstOrDefault(C => C.Fecha == request.Fecha && C.Hora == request.Hora && C.Minuto == request.Minuto && C.Medico == Medico);

            if (cita != null)
            {
                return new CitaResponse() { Message = $"Esta hora ya esta ocupada, seleccione otra" };
            }
            

            Cita NuevaCita = new Cita();
            NuevaCita.Medico = Medico;
            NuevaCita.Paciente = Paciente;
            NuevaCita.Fecha = request.Fecha;
            NuevaCita.Hora = request.Hora;
            NuevaCita.Minuto = request.Minuto;
            
            _unitOfWork.CitaRepository.Add(NuevaCita);
            _unitOfWork.Commit();
            
            return new CitaResponse() { Message = $"Se Registro su cita con el medico : {Medico.Apellidos} {Medico.Nombres}" };

          
        }


    }

    public class CitaRequest
    {
        public string Idpaciente { get; set; }
        public string Fecha { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
    
    }

    public class CitaResponse
    {
        public string Message { get; set; }
    }
}

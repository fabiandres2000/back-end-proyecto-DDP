using Domain.Contracts;
using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class CrearPacienteService
    {
        readonly IUnitOfWork _unitOfWork;
        

        public CrearPacienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public PacienteResponse CrearPaciente(PacienteRequest request)
        {
            Paciente paciente = _unitOfWork.IPacienteRepository.FindFirstOrDefault(P => P.Identificacion == request.Identificacion);
            if (paciente == null)
            {
                Paciente NuevoPaciente = new Paciente();
                NuevoPaciente.Id = request.Id;
                NuevoPaciente.Apellidos = request.Apellidos;
                NuevoPaciente.CorreoElectronico = request.CorreoElectronico;
                NuevoPaciente.DepartamentoResidencia = request.DepartamentoResidencia;
                NuevoPaciente.Direccion = request.Direccion;
                NuevoPaciente.Edad = request.Edad;
                NuevoPaciente.Estrato = request.Estrato;
                NuevoPaciente.Identificacion = request.Identificacion;
                NuevoPaciente.Municipio = request.Municipio;
                NuevoPaciente.Nombres = request.Nombres;
                NuevoPaciente.Sexo = request.Sexo;
                NuevoPaciente.Telefono = request.Telefono;
                NuevoPaciente.TipoAfiliacion = request.TipoAfiliacion;
                NuevoPaciente.Medico = request.Medico;
                if (NuevoPaciente.Guardar(NuevoPaciente).Equals("Registrado correctamente"))
                {
                     _unitOfWork.IPacienteRepository.Add(NuevoPaciente);
                     _unitOfWork.Commit(); 
                    
                     return new PacienteResponse() { Message = $"Se Registro CorrectaMente" };
                    
                }
                return new PacienteResponse() { Message = $"Digite los campos primordiales para su registro" };
            }
            else
            {
                return new PacienteResponse() { Message = $"El número de cedula ya exite" };
            }

        }
    }

    public class PacienteRequest
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public int Estrato { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public Municipio Municipio { get; set; }
        public Departamento DepartamentoResidencia { get; set; }
        public string TipoAfiliacion { get; set; }
        public Medico Medico { get; set; }

    }

    public class PacienteResponse
    {
        public string Message { get; set; }
    }
}

using Domain.Contracts;
using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class CrearMedicoService
    {
        readonly IUnitOfWork _unitOfWork;
       

        public CrearMedicoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public MedicoResponse CrearMedico(MedicoRequest request)
        {
           Medico medico = _unitOfWork.IMedicoRepository.FindFirstOrDefault(P => P.Identificacion == request.Identificacion);
            if (medico == null)
            {
                Medico NuevoMedico = new Medico();
                NuevoMedico.Id = request.Id;
                NuevoMedico.Apellidos = request.Apellidos;
                NuevoMedico.CorreoElectronico = request.CorreoElectronico;
                NuevoMedico.DepartamentoResidencia = request.DepartamentoResidencia;
                NuevoMedico.Direccion = request.Direccion;
                NuevoMedico.Edad = request.Edad;
                NuevoMedico.Estrato = request.Estrato;
                NuevoMedico.Identificacion = request.Identificacion;
                NuevoMedico.Municipio = request.Municipio;
                NuevoMedico.Nombres = request.Nombres;
                NuevoMedico.Sexo = request.Sexo;
                NuevoMedico.Telefono = request.Telefono;
                NuevoMedico.Especializacion = request.Especializacion;
               
                if (NuevoMedico.Guardar(NuevoMedico).Equals("Registrado correctamente"))
                {
                    _unitOfWork.IMedicoRepository.Add(NuevoMedico);
                    _unitOfWork.Commit();
                    
                    
                    return new MedicoResponse() { Message = $"Se Registro CorrectaMente" };
                }
                return new MedicoResponse() { Message = $"Digite los campos primordiales para su registro" };
            }
            else
            {
                return new MedicoResponse() { Message = $"El número de cedula ya exite" };
            }
        }
    }
    public class MedicoRequest
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
        public string Especializacion { get; set; }
        public Municipio Municipio { get; set; } 
        public Departamento DepartamentoResidencia { get; set; }
        public List<Paciente> Pacientes { get; set; }
        public List<Cita> Citas { get; set; }
        public List<Diagnostico> Diagnosticos { get; set; }
       

    }

    public class MedicoResponse
    {
        public string Message { get; set; }
    }
}

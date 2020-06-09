using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class LoginService
    {
        readonly IUnitOfWork _unitOfWork;


        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public LoginResponce Verificar(LoginRequest request)
        {
            if (request.Tipo=="Administrador")
            {
                Persona administrador = _unitOfWork.IAdministradorRepository.FindFirstOrDefault(P => P.Identificacion == request.Identificacion);
               return Acceder(administrador, request.Tipo);          
            }
            if (request.Tipo == "Medico")
            {
                Persona medico = _unitOfWork.IMedicoRepository.FindFirstOrDefault(P => P.Identificacion == request.Identificacion);
                return Acceder(medico, request.Tipo);
            }
            if (request.Tipo == "Paciente")
            {
                Persona paciente = _unitOfWork.IPacienteRepository.FindFirstOrDefault(P => P.Identificacion == request.Identificacion);
                return Acceder(paciente, request.Tipo);
            }

            return Acceder(null,null);
        }

        private LoginResponce Acceder(Persona persona, string tipo)
        {
            if (persona == null)
            {
                return new LoginResponce() { mensaje = $"Verifique sus credenciales de acceso" };
            }
            else
            {
                return new LoginResponce() { Persona = persona, mensaje = tipo };
            }
        }
        
    }

    public class LoginResponce
    {
        public string mensaje { get; set; }
        public Persona Persona { get; set; }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Identificacion { get; set; }
        public string Tipo { get; set; }

    }
}

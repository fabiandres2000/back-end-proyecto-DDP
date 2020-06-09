using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class CrearAdministradorService
    {
        readonly IUnitOfWork _unitOfWork;


        public CrearAdministradorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public CrearAdninistradorResponce CrearAdministrador(CrearAdninistradorRequest request)
        {
            Medico medico = _unitOfWork.IMedicoRepository.FindFirstOrDefault(P => P.Identificacion == request.Identificacion);
            if (medico == null)
            {
                Administrador NuevoAdministrador = new Administrador();
                NuevoAdministrador.Id = request.Id;
                NuevoAdministrador.Apellidos = request.Apellidos;
                NuevoAdministrador.CorreoElectronico = request.CorreoElectronico;
                NuevoAdministrador.DepartamentoResidencia = request.DepartamentoResidencia;
                NuevoAdministrador.Direccion = request.Direccion;
                NuevoAdministrador.Edad = request.Edad;
                NuevoAdministrador.Estrato = request.Estrato;
                NuevoAdministrador.Identificacion = request.Identificacion;
                NuevoAdministrador.Municipio = request.Municipio;
                NuevoAdministrador.Nombres = request.Nombres;
                NuevoAdministrador.Sexo = request.Sexo;
                NuevoAdministrador.Telefono = request.Telefono;
              
                if (NuevoAdministrador.Guardar(NuevoAdministrador).Equals("Registrado correctamente"))
                {
                    _unitOfWork.IAdministradorRepository.Add(NuevoAdministrador);
                    _unitOfWork.Commit();


                    return new CrearAdninistradorResponce() { Mensaje = $"Se Registro CorrectaMente el Administrador" };
                }
                return new CrearAdninistradorResponce() { Mensaje = $"Digite los campos primordiales para su registro" };
            }
            else
            {
                return new CrearAdninistradorResponce() { Mensaje = $"El número de cedula ya exite" };
            }
        }
    }

    public class CrearAdninistradorRequest{

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
    }

    public class CrearAdninistradorResponce
    {
        public string Mensaje { get; set; }
    }
}

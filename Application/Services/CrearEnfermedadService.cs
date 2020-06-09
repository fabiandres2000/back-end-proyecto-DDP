using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class CrearEnfermedadService
    {
        readonly IUnitOfWork _unitOfWork;


        public CrearEnfermedadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public EnfermedadResponse CrearEnfermedad(EnfermedadRequest request)
        {
            Enfermedad enfermedad = _unitOfWork.EnfermedadRepository.FindFirstOrDefault(E => E.Codigo == request.Codigo);
            if (enfermedad == null)
            {
                Enfermedad NuevaEnfermedad = new Enfermedad();
                NuevaEnfermedad.Codigo = request.Codigo;
                NuevaEnfermedad.Gravedad = request.Gravedad;
                NuevaEnfermedad.Nombre = request.Nombre;
                NuevaEnfermedad.Sintomas = request.Sintomas;
                NuevaEnfermedad.Tipo = request.Tipo;
                NuevaEnfermedad.Tratamientos = request.Tratamientos;
                if (NuevaEnfermedad.Guardar(NuevaEnfermedad).Equals("Registrado correctamente"))
                {
                    _unitOfWork.EnfermedadRepository.Add(NuevaEnfermedad);
                    _unitOfWork.Commit();
                   
                    return new EnfermedadResponse() { Message = $"Se Registro CorrectaMente" };
                }
                return new EnfermedadResponse() { Message = $"Llene todos los campos" };
            }
            else
            {
                return new EnfermedadResponse() { Message = $"Ya Existe Compa" };
            }

        }


    }
    public class EnfermedadRequest
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public List<Sintoma> Sintomas { get; set; }
        public List<Tratamiento> Tratamientos { get; set; }
        public string Gravedad { get; set; }
    }


    public class EnfermedadResponse
    {
        public string Message { get; set; }
    }
}

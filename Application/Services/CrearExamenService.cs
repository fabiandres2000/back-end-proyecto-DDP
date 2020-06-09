using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class CrearExamenService
    {
        readonly IUnitOfWork _unitOfWork;


        public CrearExamenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public TratamientoResponse CrearExamen(ExamenRequest request)
        {
            Examen examen = _unitOfWork.ExamenRepository.FindFirstOrDefault(T => T.Tipo == request.Tipo);
            if (examen == null)
            {
                Examen NuevoExamen = new Examen();
                NuevoExamen.Tipo = request.Tipo;
                if (NuevoExamen.Tipo!="")
                {
                    _unitOfWork.ExamenRepository.Add(NuevoExamen);
                    _unitOfWork.Commit();
                    return new TratamientoResponse() { Message = $"Se Registro el examen satisfactoriamente" };
                }
                return new TratamientoResponse() { Message = $"LLene todos los campos" };
            }
            else
            {
                return new TratamientoResponse() { Message = $"Ya Existe Compa :(" };
            }
        }

    }

    public class ExamenResponce
    {
        public string Message { get; set; }
    }
    public class ExamenRequest
    {
        public string Tipo { get; set; }
    }

}

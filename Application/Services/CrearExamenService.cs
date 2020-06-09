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

        public ExamenResponse CrearExamen(ExamenRequest request)
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
                    return new ExamenResponse() { Message = $"Se Registro el examen satisfactoriamente" };
                }
                return new ExamenResponse() { Message = $"LLene todos los campos" };
            }
            else
            {
                return new ExamenResponse() { Message = $"Ya Existe Compa :(" };
            }
        }

    }

    public class ExamenResponse
    {
        public string Message { get; set; }
    }
    public class ExamenRequest
    {
        public string Tipo { get; set; }
    }

}

using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class CrearSintomaService
    {
        readonly IUnitOfWork _unitOfWork;


        public CrearSintomaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public SintomaResponse CrearSitoma(SintomaRequest request)
        {
            Sintoma sintoma = _unitOfWork.SintomaRepository.FindFirstOrDefault(S => S.Codigo == request.Codigo);
            if (sintoma == null)
            {
                Sintoma NuevoSintoma = new Sintoma();
                NuevoSintoma.Codigo = request.Codigo;
                NuevoSintoma.Descripcion = request.Descripcion;
                _unitOfWork.SintomaRepository.Add(NuevoSintoma);
                _unitOfWork.Commit();
               
                return new SintomaResponse() { Message = $"Se Registro" };

            }
            else
            {
                return new SintomaResponse() { Message = $"Ya Existe Compa" };
            }
        }

    }

    public class SintomaResponse
    {
        public string Message { get; set; }
    }
    public class SintomaRequest
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}

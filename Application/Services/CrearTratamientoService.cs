using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class CrearTratamientoService
    {
        readonly IUnitOfWork _unitOfWork;


        public CrearTratamientoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public TratamientoResponse CrearTratamiento(TratamientoRequest request)
        {
            Tratamiento tratamiento = _unitOfWork.TratamientoRepository.FindFirstOrDefault(T => T.Codigo == request.Codigo);
            if (tratamiento == null)
            {
                Tratamiento NuevoTratamiento = new Tratamiento();
                NuevoTratamiento.Codigo = request.Codigo;
                NuevoTratamiento.Descripcion = request.Descripcion;
                if (NuevoTratamiento.Guardar(NuevoTratamiento).Equals("se guardo todo cachon"))
                {
                    _unitOfWork.TratamientoRepository.Add(NuevoTratamiento);
                    _unitOfWork.Commit();
                return new TratamientoResponse() { Message = $"Se Registro" };
                }
                return new TratamientoResponse() { Message = $"LLene todos los campos" };
            }
            else
            {
                return new TratamientoResponse() { Message = $"Ya Existe Compa" };
            }
        }

    }

    public class TratamientoResponse
    {
        public string Message { get; set; }
    }
    public class TratamientoRequest
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}

using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class CrearEnfermedadTratamientoService
    {
        readonly IUnitOfWork _unitOfWork;


        public CrearEnfermedadTratamientoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public EnfermedadTratamientoResponse CrearEnfermedadTratamiento(EnfermedadTratamientoRequest request)
        {
            var verificacion = _unitOfWork.IEnfermedadTratamientoRepository.FindFirstOrDefault(p => p.enfermedad.Codigo == request.IDenfermedad && p.tratamiento.Codigo == request.IDTratamiento);

            if (verificacion!=null)
            {
                return new EnfermedadTratamientoResponse() { Message = $"Ya se habia asociado esta enfermedad y este tratamiento" };
            }

            request.tratamiento = _unitOfWork.TratamientoRepository.FindFirstOrDefault(p => p.Codigo == request.IDTratamiento);
            request.Enfermedad = _unitOfWork.EnfermedadRepository.FindFirstOrDefault(P => P.Codigo == request.IDenfermedad);

            EnfermedadTratamiento NuevoEnfermedadTratamiento = new EnfermedadTratamiento();

            NuevoEnfermedadTratamiento.enfermedad = request.Enfermedad;
            NuevoEnfermedadTratamiento.tratamiento = request.tratamiento;
            if (NuevoEnfermedadTratamiento.Guardar(NuevoEnfermedadTratamiento).Equals("se guardo todo cachon"))
            {
                _unitOfWork.IEnfermedadTratamientoRepository.Add(NuevoEnfermedadTratamiento);
                _unitOfWork.Commit();
                return new EnfermedadTratamientoResponse() { Message = $"Se Asocio Correctamente la Enfermedad Y el sintoma" };
            }
            return new EnfermedadTratamientoResponse() { Message = $"Llene Todos los campos" };
        }
    }

    public class EnfermedadTratamientoRequest
    {
        public string IDTratamiento{ get; set; }
        public string IDenfermedad { get; set; }
        public Tratamiento tratamiento { get; set; }
        public Enfermedad Enfermedad { get; set; }

    }

    public class EnfermedadTratamientoResponse
    {
        public string Message { get; set; }
    }
}

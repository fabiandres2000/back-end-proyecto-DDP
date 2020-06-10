using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application.Services
{
    public class CompletarDiagnosticoService
    {
        readonly IUnitOfWork _unitOfWork;


        public CompletarDiagnosticoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public CompletarDiagnosticoResponse Completar(CompletarDiagnosticoRequest request) {
            var DiagnosticoPendiente  = _unitOfWork.DiagnosticoRepository.FindFirstOrDefault(x=>x.Id == request.Id);
            var tratamiento = _unitOfWork.TratamientoRepository.FindFirstOrDefault(y=>y.Codigo == request.Tratamiento);
            var examen = _unitOfWork.ExamenRepository.FindFirstOrDefault(z=>z.Id == request.Examen);
            DiagnosticoPendiente.Examen = examen;
            DiagnosticoPendiente.Tratamiento = tratamiento;
            DiagnosticoPendiente.RecomendacionMedica = request.RecomendacionMedica;
            DiagnosticoPendiente.Estado = "Revisado";
            
            _unitOfWork.DiagnosticoRepository.Edit(DiagnosticoPendiente);
            _unitOfWork.Commit();
            return new CompletarDiagnosticoResponse() { Message = $"Se Reviso Diagnostico" };
        }
    }

    public class CompletarDiagnosticoRequest
    {
        public string RecomendacionMedica { get; set; }
        public int Examen { get; set; }
        public string Tratamiento { get; set; }
        public int Id { get; set; }

    }

    public class CompletarDiagnosticoResponse
    {
        public string Message { get; set; }

    }
}

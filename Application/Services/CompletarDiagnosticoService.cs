using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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


           ConsultarDiagnosticoService consultarDiagnostico = new ConsultarDiagnosticoService(_unitOfWork);
            var DiagnosticoPendiente=consultarDiagnostico.Diagnostico(request.Estado, request.Id);
            DiagnosticoPendiente.RecomendacionMedica = request.RecomendacionMedica;
            DiagnosticoPendiente.Estado = "Revisado";
            
            _unitOfWork.DiagnosticoRepository.Edit(DiagnosticoPendiente);
            _unitOfWork.Commit();
            _unitOfWork.Dispose();

            return new CompletarDiagnosticoResponse() { Message = $"Se Reviso Diagnostico" };
        }
          
            
            
        
    }

    public class CompletarDiagnosticoRequest
    {
        public string RecomendacionMedica { get; set; }
        public string Estado { get; set; }
        public int Id { get; set; }
    }

    public class CompletarDiagnosticoResponse
    {
        public string Message { get; set; }

    }
}

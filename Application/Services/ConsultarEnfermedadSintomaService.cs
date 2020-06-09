using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class ConsultarEnfermedadSintomaService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarEnfermedadSintomaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        
        }

        public List<ConsultarEnfermedadSintomaResponse> Consultar()
        {
            List<ConsultarEnfermedadSintomaResponse> lista = new List<ConsultarEnfermedadSintomaResponse>();
            var enfermedadsintoma = _unitOfWork.IEnfermedadSintoma.FindBy(includeProperties: "Sintoma,Enfermedad").ToList();
            foreach (var Item in enfermedadsintoma)
            { 
                ConsultarEnfermedadSintomaResponse co = new ConsultarEnfermedadSintomaResponse();
                co.Enfermedad = Item.Enfermedad;
                co.Sintoma = Item.Sintoma;
                co.id = Item.Id;
                lista.Add(co);
            }
            return lista;
        }
      
    }  
    public class ConsultarEnfermedadSintomaResponse
    {
            public int id { get; set; }
            public Sintoma Sintoma { get; set; }
            public Enfermedad Enfermedad { get; set; }

    }
}

using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class ConsultarEnfermedadTratamientoService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarEnfermedadTratamientoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<ConsultarEnfermedadTratamientoResponse> ConsultarEnfermedadTratamiento()
        {
            List<ConsultarEnfermedadTratamientoResponse> lista = new List<ConsultarEnfermedadTratamientoResponse>();
            var enfermedadtratamiento = _unitOfWork.IEnfermedadTratamientoRepository.FindBy(includeProperties: "tratamiento,enfermedad").ToList();
            foreach (var Item in enfermedadtratamiento)
            {
                ConsultarEnfermedadTratamientoResponse co = new ConsultarEnfermedadTratamientoResponse();
                co.Enfermedad = Item.enfermedad;
                co.Tratamiento = Item.tratamiento;
                co.id = Item.Id;
                lista.Add(co);
            }
            return lista;
        }

    }

    public class ConsultarEnfermedadTratamientoResponse
    {
        public int id { get; set; }
        public Tratamiento Tratamiento { get; set; }
        public Enfermedad Enfermedad { get; set; }

    }

}

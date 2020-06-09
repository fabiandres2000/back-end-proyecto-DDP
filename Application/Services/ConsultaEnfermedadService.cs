using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class ConsultaEnfermedadService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultaEnfermedadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public List<Enfermedad> GetAll()
        {

            var res = _unitOfWork.EnfermedadRepository.GetAll();
            _unitOfWork.Dispose();
            return res.ToList();
        }
    }
}

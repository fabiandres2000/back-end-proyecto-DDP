using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class ConsultarExamenService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarExamenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<Examen> GetAll()
        {
            var res = _unitOfWork.ExamenRepository.GetAll();
            return res.ToList();
        }
    }
}

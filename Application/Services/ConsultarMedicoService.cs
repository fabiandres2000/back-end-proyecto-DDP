using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class ConsultarMedicoService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarMedicoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public List<Medico> GetAll()
        {

            var res = _unitOfWork.IMedicoRepository.FindBy(includeProperties: "Municipio,DepartamentoResidencia");
            _unitOfWork.Dispose();
            return res.ToList();
        }


        public Medico GetId(int id)
        {
            var ConsultarID = _unitOfWork.IMedicoRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }
    }
}

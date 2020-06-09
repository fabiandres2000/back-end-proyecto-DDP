using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class ConsultarAdministradorService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarAdministradorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<Administrador> GetAll()
        {
            var res = _unitOfWork.IAdministradorRepository.FindBy(includeProperties: "Municipio,DepartamentoResidencia");
            _unitOfWork.Dispose();
            return res.ToList();
        }

        public Administrador GetId(int id)
        {
            var ConsultarID = _unitOfWork.IAdministradorRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }
    }
}

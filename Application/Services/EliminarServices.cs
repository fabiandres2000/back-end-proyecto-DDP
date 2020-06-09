using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class EliminarServices
    {
        readonly IUnitOfWork _unitOfWork;


        public EliminarServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public EliminarResponse DeleteEnfermedad(string codigo)
        {

            Enfermedad enfermedad = _unitOfWork.EnfermedadRepository.FindFirstOrDefault(p=> p.Codigo == codigo);
            var enfermedadSintoma = _unitOfWork.IEnfermedadSintoma.FindBy(p => p.Enfermedad.Codigo == codigo, includeProperties: "Sintoma,Enfermedad").ToList();
            var enfermedadTratamiento = _unitOfWork.IEnfermedadTratamientoRepository.FindBy(p => p.enfermedad.Codigo == codigo, includeProperties: "tratamiento,enfermedad").ToList();
            if (enfermedad == null)
            {
                return new EliminarResponse() { Message = $"No Existe la enfermedad" };
            }
            else
            {
                _unitOfWork.EnfermedadRepository.Delete(enfermedad);
                if (enfermedadSintoma != null)
                {
                    _unitOfWork.IEnfermedadSintoma.DeleteRange(enfermedadSintoma);
                }
                if (enfermedadTratamiento != null)
                {
                    _unitOfWork.IEnfermedadTratamientoRepository.DeleteRange(enfermedadTratamiento);
                }

                _unitOfWork.Commit();
                return new EliminarResponse() { Message = $"Se elimio la enfermedad" };
            }
        }
        public EliminarResponse DeleteSintoma(string id)
        {

            Sintoma sintoma = _unitOfWork.SintomaRepository.FindFirstOrDefault(p=>p.Codigo==id);
            var enfermedadSintoma = _unitOfWork.IEnfermedadSintoma.FindBy(p => p.Sintoma.Codigo == id, includeProperties: "Sintoma,Enfermedad").ToList();
            if (sintoma == null)
            {
                return new EliminarResponse() { Message = $"No Existe el sintoma" };
            }
            else
            {
                _unitOfWork.SintomaRepository.Delete(sintoma);
                if (enfermedadSintoma != null)
                {
                    _unitOfWork.IEnfermedadSintoma.DeleteRange(enfermedadSintoma);
                }
                _unitOfWork.Commit();
                return new EliminarResponse() { Message = $"Se Elimio el sintoma" };
            }
        }

        public EliminarResponse DeleteTratamiento(string id)
        {

            Tratamiento tratamiento = _unitOfWork.TratamientoRepository.FindFirstOrDefault(p=> p.Codigo==id);
            var enfermedadTratamiento = _unitOfWork.IEnfermedadTratamientoRepository.FindBy(p => p.tratamiento.Codigo == id, includeProperties: "tratamiento,enfermedad").ToList();

            if (tratamiento == null)
            {
                return new EliminarResponse() { Message = $"No Existe el tratamiento" };
            }
            else
            {
                _unitOfWork.TratamientoRepository.Delete(tratamiento);
                if (enfermedadTratamiento != null)
                {
                    _unitOfWork.IEnfermedadTratamientoRepository.DeleteRange(enfermedadTratamiento);
                }
                _unitOfWork.Commit();
                return new EliminarResponse() { Message = $"Se Elimio el tratamiento" };
            }
        }


        public EliminarResponse DeletePaciente(string id)
        {

            Paciente paciente = _unitOfWork.IPacienteRepository.FindFirstOrDefault(pa=>pa.Identificacion == id);

            if (paciente == null)
            {
                return new EliminarResponse() { Message = $"No Existe el paciente" };
            }
            else
            {
                _unitOfWork.IPacienteRepository.Delete(paciente);
                _unitOfWork.Commit();
                return new EliminarResponse() { Message = $"Se Elimio el paciente" };
            }
        }

        public EliminarResponse DeleteMedico(string  id)
        {

            Medico medico = _unitOfWork.IMedicoRepository.FindFirstOrDefault(pa => pa.Identificacion == id);

            if (medico == null)
            {
                return new EliminarResponse() { Message = $"No Existe el medico" };
            }
            else
            {
                _unitOfWork.IMedicoRepository.Delete(medico);
                _unitOfWork.Commit();
                return new EliminarResponse() { Message = $"Se Elimio el medico" };
            }
        }

        public EliminarResponse DeleteAdministrador(string id)
        {

            Administrador administrador = _unitOfWork.IAdministradorRepository.FindFirstOrDefault(pa => pa.Identificacion == id);

            if (administrador == null)
            {
                return new EliminarResponse() { Message = $"No Existe el administrador" };
            }
            else
            {
                _unitOfWork.IAdministradorRepository.Delete(administrador);
                _unitOfWork.Commit();
                return new EliminarResponse() { Message = $"Se Elimio el administrador" };
            }
        }

        public EliminarResponse ElminarEnfermedadSintoma(int id)
        {
            EnfermedadSintoma enfermedadSintoma = _unitOfWork.IEnfermedadSintoma.Find(id);
            if (enfermedadSintoma == null)
            {
                return new EliminarResponse() { Message = $"No Existe" };
            }
            else
            {
                _unitOfWork.IEnfermedadSintoma.Delete(enfermedadSintoma);
                _unitOfWork.Commit();
                return new EliminarResponse() { Message = $"Se Elimio" };
            }

        }

        public EliminarResponse ElminarEnfermedadTratamiento(int id)
        {
            EnfermedadTratamiento enfermedadTratamiento = _unitOfWork.IEnfermedadTratamientoRepository.Find(id);
            if (enfermedadTratamiento == null)
            {
                return new EliminarResponse() { Message = $"No Existe" };
            }
            else
            {
                _unitOfWork.IEnfermedadTratamientoRepository.Delete(enfermedadTratamiento);
                _unitOfWork.Commit();
                return new EliminarResponse() { Message = $"Se Elimio" };
            }

        }



    }

    public class EliminarResponse
    {
        public string Message { get; set; }
    }
}

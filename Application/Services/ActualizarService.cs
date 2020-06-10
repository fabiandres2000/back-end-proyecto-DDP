using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class ActualizarService
    {

        readonly IUnitOfWork _unitOfWork;


        public ActualizarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public EnfermedadResponse ActualizarEnfermedad(EnfermedadRequest request)
        {
            var Buscar = _unitOfWork.EnfermedadRepository.FindFirstOrDefault(P => P.Codigo == request.Codigo);
            if (Buscar != null)
            {
                Buscar.Gravedad = request.Gravedad;
                Buscar.Nombre = request.Nombre;
                Buscar.Tipo = request.Tipo;
                _unitOfWork.EnfermedadRepository.Edit(Buscar);
                _unitOfWork.Commit();
                return new EnfermedadResponse() { Message = $"Los datos de la enfermedad fueron actualizados correctamente." };
            }
            else
            {
                return new EnfermedadResponse() { Message = $"No Existe Cachon" };

            }

        }


        public SintomaResponse ActualizarSintoma(SintomaRequest request)
        {
            var Buscar = _unitOfWork.SintomaRepository.FindFirstOrDefault(P => P.Codigo == request.Codigo);
            if (Buscar != null)
            {
                Buscar.Descripcion = request.Descripcion;
                _unitOfWork.SintomaRepository.Edit(Buscar);
                _unitOfWork.Commit();
                return new SintomaResponse() { Message = $"Los datos del sintoma fueron actualizados correctamente." };
            }
            else
            {
                return new SintomaResponse() { Message = $"Nada No Existe" };

            }


        }

        public TratamientoResponse ActualizarTratamiento(TratamientoRequest request)
        {
            var Buscar = _unitOfWork.TratamientoRepository.FindFirstOrDefault(P => P.Codigo == request.Codigo);
            if (Buscar != null)
            {
                Buscar.Descripcion = request.Descripcion;
                _unitOfWork.TratamientoRepository.Edit(Buscar);
                _unitOfWork.Commit();
                return new TratamientoResponse() { Message = $"Los datos del tratamiento fueron actualizados correctamente." };
            }
            else
            {
                return new TratamientoResponse() { Message = $"Nada No Existe" };

            }


        }

        public EnfermedadTratamientoResponse ActualizarEnfermedadTratamiento(EnfermedadTratamientoRequest request)
        {
            var Buscar = _unitOfWork.IEnfermedadTratamientoRepository.FindFirstOrDefault(p => p.enfermedad.Codigo == request.IDenfermedad && p.tratamiento.Codigo == request.IDTratamiento);
            if (Buscar != null)
            {
                Buscar.enfermedad = request.Enfermedad;
                Buscar.tratamiento = request.tratamiento;
                _unitOfWork.IEnfermedadTratamientoRepository.Edit(Buscar);
                _unitOfWork.Commit();
                return new EnfermedadTratamientoResponse() { Message = $"Los datos fueron actualizados correctamente." };
            }
            else
            {
                return new EnfermedadTratamientoResponse() { Message = $"Negativo No Existe" };
            }

        }

        public EnfermedadSintomaResponse ActualizarEnfermedadSintoma(EnfermedadSintomaRequest request)
        {
            var Buscar = _unitOfWork.IEnfermedadSintoma.FindFirstOrDefault(p => p.Enfermedad.Codigo == request.IDenfermedad && p.Sintoma.Codigo == request.IDsintoma);
            if (Buscar != null)
            {
                Buscar.Enfermedad = request.Enfermedad;
                Buscar.Sintoma = request.Sintoma;
                _unitOfWork.IEnfermedadSintoma.Edit(Buscar);
                _unitOfWork.Commit();
                return new EnfermedadSintomaResponse() { Message = $"Los datos fueron actualizados correctamente." };
            }
            else
            {
                return new EnfermedadSintomaResponse() { Message = $"Negativo No Existe" };
            }

        }

        public PacienteResponse ActualizarPaciente(PacienteRequest request)
        {
            var Buscar = _unitOfWork.IPacienteRepository.FindFirstOrDefault(P => P.Identificacion == request.Identificacion);
            if (Buscar != null)
            {
                Buscar.Apellidos = request.Apellidos;
                Buscar.CorreoElectronico = request.CorreoElectronico;
                Buscar.DepartamentoResidencia = request.DepartamentoResidencia;
                Buscar.Direccion = request.Direccion;
                Buscar.Edad = request.Edad;
                Buscar.Estrato = request.Estrato;
                Buscar.Identificacion = request.Identificacion;
                Buscar.Municipio = request.Municipio;
                Buscar.Nombres = request.Nombres;
                Buscar.Sexo = request.Sexo;
                Buscar.Telefono = request.Telefono;
                Buscar.TipoAfiliacion = request.TipoAfiliacion;
                Buscar.Medico = request.Medico;
                _unitOfWork.IPacienteRepository.Edit(Buscar);
                _unitOfWork.Commit();
                return new PacienteResponse() { Message = $"Sus datos fueron actualizados correctamente, por favor vuelva a iniciar sesion para que se reflejen los cambios." };
            }
            else
            {
                return new PacienteResponse() { Message = $"Negativo No Existe" };

            }

        }

        public MedicoResponse ActualizarMedico(MedicoRequest request)
        {
            var Buscar = _unitOfWork.IMedicoRepository.FindFirstOrDefault(P => P.Identificacion == request.Identificacion);
            if (Buscar != null)
            {
                Buscar.Apellidos = request.Apellidos;
                Buscar.CorreoElectronico = request.CorreoElectronico;
                Buscar.DepartamentoResidencia = request.DepartamentoResidencia;
                Buscar.Direccion = request.Direccion;
                Buscar.Edad = request.Edad;
                Buscar.Estrato = request.Estrato;
                Buscar.Identificacion = request.Identificacion;
                Buscar.Municipio = request.Municipio;
                Buscar.Nombres = request.Nombres;
                Buscar.Sexo = request.Sexo;
                Buscar.Telefono = request.Telefono;
                Buscar.Especializacion = request.Especializacion;
                _unitOfWork.IMedicoRepository.Edit(Buscar);
                _unitOfWork.Commit();
                return new MedicoResponse() { Message = $"Sus datos fueron actualizados correctamente, por favor vuelva a iniciar sesion para que se reflejen los cambios." };

            }
            else
            {
                return new MedicoResponse() { Message = $"Negativo No Existe :(" };

            }
        }



    }



}

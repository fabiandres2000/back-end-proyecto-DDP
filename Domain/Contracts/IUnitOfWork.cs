using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
       
        ITratamientoRepository TratamientoRepository { get; }
        IEnfermedadRepository EnfermedadRepository { get; }
        ISintomaRepository SintomaRepository { get; }
        ICitaRepository CitaRepository { get; }
        IDepartamentoRepository IDepartamentoRepository { get; }
        IDiagnosticoRepository DiagnosticoRepository { get; }
        IEpsRepository EpsRepository { get; }
        IExamenRepository ExamenRepository { get; }
        IHistorialCitaRepository IHistorialCitaRepository { get; }
        IHistorialMedicoRepository IHistorialMedicoRepository { get; }
        IMunicipioRepository IMunicipioRepository { get; }
        IEnfermedadSintomaRepository IEnfermedadSintoma { get; }
        IEnfermedadTratamientoRepository IEnfermedadTratamientoRepository { get; }
        IExamenDiagnosticoRepository IExamenDiagnosticoRepository { get; }
        IPacienteRepository IPacienteRepository { get; }
        IMedicoRepository IMedicoRepository { get; }
        IAdministradorRepository IAdministradorRepository { get; }
        int Commit();
    }
}

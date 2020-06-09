using Domain.Contracts;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Base
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        

        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }
        private ITratamientoRepository _tratamientoRepository;
        private IEnfermedadRepository _enfermedadRepository;
        private ISintomaRepository _sintomaRepository;
        private ICitaRepository _citaRepository;
        private IDepartamentoRepository _departamentoRepository;
        private IDiagnosticoRepository _diagnosticoRepository;
        private IEpsRepository _epsRepository;
        private IExamenRepository _examenRepository;
        private IHistorialCitaRepository _historialcitaRepository;
        private IHistorialMedicoRepository _historialmedicoRepository;
        private IMunicipioRepository _municipioRepository;
        private IEnfermedadSintomaRepository _enfermedadSintomaRepository;
        private IEnfermedadTratamientoRepository _enfermedadtratamientorepository;
        private IExamenDiagnosticoRepository _examendiagnosticorepository;
        private IPacienteRepository _pacienteRepository;
        private IMedicoRepository _medicoRepository;
        private IAdministradorRepository _administradorRepository;

        public ITratamientoRepository TratamientoRepository
        {
            get
            {

                if (_tratamientoRepository == null)
                {
                    _tratamientoRepository = new TratamientoRepository(_dbContext);
                }
                return _tratamientoRepository;
            }
        }

        public IEnfermedadRepository EnfermedadRepository
        {
            get
            {

                if (_enfermedadRepository == null)
                {
                    _enfermedadRepository = new EnfermedadRepository(_dbContext);
                }
                return _enfermedadRepository;
            }
        }
        public ISintomaRepository SintomaRepository
        {
            get
            {

                if (_sintomaRepository == null)
                {
                    _sintomaRepository = new SintomaRepository(_dbContext);
                }
                return _sintomaRepository;
            }
        }
        public ICitaRepository CitaRepository
        {
            get
            {

                if (_citaRepository == null)
                {
                    _citaRepository = new CitaRepository(_dbContext);
                }
                return _citaRepository;
            }
        }
        public IDepartamentoRepository IDepartamentoRepository
        {
            get
            {

                if (_departamentoRepository == null)
                {
                    _departamentoRepository = new DepartamentoRepository(_dbContext);
                }
                return _departamentoRepository;
            }
        }
        
        public IDiagnosticoRepository DiagnosticoRepository
        {
            get
            {

                if (_diagnosticoRepository == null)
                {
                    _diagnosticoRepository = new DiagnosticoRepository(_dbContext);
                }
                return _diagnosticoRepository;
            }
        }

        public IEpsRepository EpsRepository
        {
            get
            {

                if (_epsRepository == null)
                {
                    _epsRepository = new EpsRepository(_dbContext);
                }
                return _epsRepository;
            }
        }
        public IExamenRepository ExamenRepository
        {
            get
            {

                if (_examenRepository == null)
                {
                    _examenRepository = new ExamenRepository(_dbContext);
                }
                return _examenRepository;
            }
        }
        public IHistorialCitaRepository IHistorialCitaRepository
        {
            get
            {

                if (_historialcitaRepository == null)
                {
                    _historialcitaRepository = new HistorialCitaRepository(_dbContext);
                }
                return _historialcitaRepository;
            }
        }
        public IHistorialMedicoRepository IHistorialMedicoRepository
        {
            get
            {

                if (_historialmedicoRepository == null)
                {
                    _historialmedicoRepository = new HistorialMedicoRepository(_dbContext);
                }
                return _historialmedicoRepository;
            }
        }
        public IMunicipioRepository IMunicipioRepository
        {
            get
            {

                if (_municipioRepository == null)
                {
                    _municipioRepository = new MunicipioRepository(_dbContext);
                }
                return _municipioRepository;
            }
        }

       

        public IEnfermedadSintomaRepository IEnfermedadSintoma
        {
            get
            {

                if (_enfermedadSintomaRepository == null)
                {
                    _enfermedadSintomaRepository = new EnfermedadSintomaRepository(_dbContext);
                }
                return _enfermedadSintomaRepository;
            }
        }

        public IEnfermedadTratamientoRepository IEnfermedadTratamientoRepository
        {
            get
            {

                if (_enfermedadtratamientorepository == null)
                {
                    _enfermedadtratamientorepository = new EnfermedadTratamientoRepository(_dbContext);
                }
                return _enfermedadtratamientorepository;
            }
        }

        public IExamenDiagnosticoRepository IExamenDiagnosticoRepository
        {
            get
            {

                if (_examendiagnosticorepository == null)
                {
                    _examendiagnosticorepository = new ExamenDiagnosticoRepository(_dbContext);
                }
                return _examendiagnosticorepository;
            }
        }
        public IPacienteRepository IPacienteRepository
        {
            get
            {

                if (_pacienteRepository == null)
                {
                    _pacienteRepository = new PacienteRepository(_dbContext);
                }
                return _pacienteRepository;
            }
        }

        public IMedicoRepository IMedicoRepository
        {
            get
            {
                if (_medicoRepository == null)
                {
                    _medicoRepository = new MedicoRepository(_dbContext);
                }
                return _medicoRepository;
            }
        }

        public IAdministradorRepository IAdministradorRepository
        {
            get
            {
                if (_administradorRepository == null)
                {
                    _administradorRepository = new AdministradorRepository(_dbContext);
                }
                return _administradorRepository;
            }
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }

    }
}

using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ExamenDiagnosticoRepository : GenericRepository<ExamenDiagnostico>, IExamenDiagnosticoRepository
    {
        public ExamenDiagnosticoRepository(IDbContext context)
            : base(context)
        {

        }
    }
}

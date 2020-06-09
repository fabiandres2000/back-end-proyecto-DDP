using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class DiagnosticoRepository : GenericRepository<Diagnostico>, IDiagnosticoRepository
    {
        public DiagnosticoRepository(IDbContext context)
            : base(context)
        {

        }
    }
}

using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class HistorialMedicoRepository : GenericRepository<HistorialMedico>, IHistorialMedicoRepository
    {
        public HistorialMedicoRepository(IDbContext context)
            : base(context)
        {

        }
    }
}

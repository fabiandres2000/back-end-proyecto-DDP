using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class HistorialCitaRepository : GenericRepository<HistorialCita>, IHistorialCitaRepository
    {
        public HistorialCitaRepository(IDbContext context)
            : base(context)
        {

        }
    }
}

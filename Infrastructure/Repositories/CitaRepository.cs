using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class CitaRepository : GenericRepository<Cita>, ICitaRepository
    {
        public CitaRepository(IDbContext context)
             : base(context)
        {

        }
    }
}

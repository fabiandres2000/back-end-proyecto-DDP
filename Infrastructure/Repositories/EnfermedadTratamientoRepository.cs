using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class EnfermedadTratamientoRepository : GenericRepository<EnfermedadTratamiento>, IEnfermedadTratamientoRepository
    {
        public EnfermedadTratamientoRepository(IDbContext context)
            : base(context)
        {

        }
    }
}

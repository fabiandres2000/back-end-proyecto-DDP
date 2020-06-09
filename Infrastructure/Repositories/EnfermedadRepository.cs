using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class EnfermedadRepository : GenericRepository<Enfermedad>, IEnfermedadRepository
    {
        public EnfermedadRepository(IDbContext context)
            : base(context)
        {

        }
    }
}

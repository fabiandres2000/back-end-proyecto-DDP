using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class SintomaRepository : GenericRepository<Sintoma>, ISintomaRepository
    {
        public SintomaRepository(IDbContext context)
            : base(context)
        {

        }
    }
}

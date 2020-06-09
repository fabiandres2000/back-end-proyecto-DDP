using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class EpsRepository : GenericRepository<Eps>, IEpsRepository
    {
        public EpsRepository(IDbContext context)
            : base(context)
        {

        }
    }
}

using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class MunicipioRepository : GenericRepository<Municipio>, IMunicipioRepository
    {
        public MunicipioRepository(IDbContext context)
            : base(context)
        {

        }
    }
}

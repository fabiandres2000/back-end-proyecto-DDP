using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TratamientoRepository : GenericRepository<Tratamiento>, ITratamientoRepository
    {
        public TratamientoRepository(IDbContext context)
            : base(context)
        {

        }
    }
}

using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;
namespace Infrastructure.Repositories
{
    public class MedicoRepository : GenericRepository<Medico>, IMedicoRepository
    {
        public MedicoRepository(IDbContext context)
            : base(context)
        {

        }
    }
}

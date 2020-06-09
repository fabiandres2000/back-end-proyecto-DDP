using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class AdministradorRepository : GenericRepository<Administrador>, IAdministradorRepository
    {
        public AdministradorRepository(IDbContext context)
             : base(context)
        {

        }
    }
}

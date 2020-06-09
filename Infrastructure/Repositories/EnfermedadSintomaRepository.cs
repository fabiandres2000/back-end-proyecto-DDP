using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;


namespace Infrastructure.Repositories
{
    public class EnfermedadSintomaRepository : GenericRepository<EnfermedadSintoma>, IEnfermedadSintomaRepository
    {
         public EnfermedadSintomaRepository(IDbContext context)
            : base(context)
         {

         }
    }
}

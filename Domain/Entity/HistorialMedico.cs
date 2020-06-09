using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Entity
{
    public class HistorialMedico : Entity<int>
    {
        public List<Diagnostico> Diagnosticos ;
        
        public HistorialMedico()
        {
            Diagnosticos = new List<Diagnostico>();
        }
    } 
}

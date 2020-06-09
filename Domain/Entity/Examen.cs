using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Examen : Entity<int>
    {
        public string Tipo { get; set; }
        
    }
}

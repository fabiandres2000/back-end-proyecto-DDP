using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class ExamenDiagnostico : Entity<int>
    {
        public Examen Examen { get; set; }
        public Diagnostico Diagnostico { get; set; }
    }
}

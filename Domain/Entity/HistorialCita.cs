using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class HistorialCita : Entity<int>
    {
        public List<Cita> citas;

        public HistorialCita()
        {
            citas = new List<Cita>();
        }
    }
}

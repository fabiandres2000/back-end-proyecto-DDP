using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class EnfermedadTratamiento : Entity<int>
    {
        public Enfermedad enfermedad { get; set; }
        public Tratamiento tratamiento { get; set; }

        public string Guardar(EnfermedadTratamiento ETratamiento)
        {
            if (ETratamiento.enfermedad == null || ETratamiento.tratamiento == null)
            {
                throw new InvalidOperationException("Llene todos los campos");
            }
            else
            {
                return "se guardo todo cachon";
            }
        }
    }
}

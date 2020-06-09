using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Tratamiento : Entity<int>
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public string Guardar(Tratamiento tratamiento)
        {
            if (tratamiento.Codigo == null || tratamiento.Descripcion == null)
            {
                throw new InvalidOperationException("Llene todos los campos");
            }
            else
            {
                this.Codigo = tratamiento.Codigo;
                this.Descripcion = tratamiento.Descripcion;
                return "se guardo todo cachon";
            }
        }
    }
}

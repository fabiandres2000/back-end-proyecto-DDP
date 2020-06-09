using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Sintoma : Entity<int>
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public void Guardar(Sintoma sintoma)
        {
            if (sintoma.Codigo == null || sintoma.Descripcion == null)
            {
                throw new InvalidOperationException("Llene todos los campos");
            }
            else
            {
                this.Codigo = sintoma.Codigo;
                this.Descripcion = sintoma.Descripcion;
                throw new InvalidOperationException("se guardo todo cachon");
            }
        }
    }
    
    public class EnfermedadSintoma : Entity<int>
    {
        public Sintoma Sintoma { get; set; }
        public Enfermedad Enfermedad { get; set; }

        public string Guardar(EnfermedadSintoma Esintoma)
        {
            if (Esintoma.Enfermedad == null || Esintoma.Sintoma == null)
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

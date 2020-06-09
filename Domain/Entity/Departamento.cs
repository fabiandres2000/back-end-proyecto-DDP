using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Departamento : Entity<int>
    {

        public string IdDimension { get; set; }
        public string Nombre { get; set; }
         
        public Departamento()
        {
           
        }

        public string Guardar(Departamento departamento)
        {
            if (departamento.Nombre == null || departamento.IdDimension==null)
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

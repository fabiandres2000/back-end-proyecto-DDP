using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Municipio : Entity<int>
    {
        public string IdDimension { get; set; }
        public string Nombre { get; set; }
        public Departamento Departamento { get; set; } 
        
        public Municipio()
        {

        }

        public string Guardar(Municipio municipio)
        {
            if (municipio.Nombre == null || municipio.IdDimension == null)
            {
                throw new InvalidOperationException("Llene todos los campos");
            }
            else
            {
                if (municipio.Departamento==null) {
                    throw new InvalidOperationException("falta asociar a un departamento");
                }
                else
                {
                    this.Nombre = municipio.Nombre;
                    this.IdDimension = municipio.IdDimension;
                    return "se guardo todo cachon";
                }
               
            }
        }
    }
}

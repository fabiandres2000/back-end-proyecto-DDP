using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Entity
{
    public class Administrador : Entity<int> ,Persona
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public int Estrato { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public Municipio Municipio { get; set; }
        public Departamento DepartamentoResidencia { get; set; }
      
        public Administrador()
        {
           
            Edad = 0;
        }

      public string Guardar(Administrador admin)
      {
            if (admin.Identificacion ==null || admin.Nombres==null || admin.Apellidos == null || admin.Edad == 0 || admin.Direccion == null)
            {
                return "Digite los campos primordiales para su registro";
            }
            else
            {
              
                return "Registrado correctamente";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Entity
{
    public  interface Persona
    {

         string Identificacion { get; set; }
         string Nombres { get; set; }
         string Apellidos { get; set; }
         int Edad { get; set; }
         int Estrato { get; set; }
         string Telefono { get; set; }
         string Sexo { get; set; }
         string CorreoElectronico { get; set; }
         String Direccion { get; set; }
         Municipio Municipio { get; set; }
         Departamento DepartamentoResidencia { get; set; }
        

    }
}

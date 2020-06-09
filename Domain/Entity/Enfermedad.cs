using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Enfermedad : Entity<int>
    {
        public string Codigo { get; set;}
        public string Nombre { get; set; }  
        public string Tipo { get; set; }
        public List<Sintoma> Sintomas { get; set; }
        public List<Tratamiento> Tratamientos { get; set; }
        public string Gravedad { get; set; }
        
        public Enfermedad()
        {
            Sintomas = new List<Sintoma>();
            Tratamientos = new List<Tratamiento>();
        }

        public string Guardar(Enfermedad enfermedad)
        {
            if (enfermedad.Codigo== null || enfermedad.Nombre == null || enfermedad.Tipo == null || enfermedad.Gravedad == null)
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

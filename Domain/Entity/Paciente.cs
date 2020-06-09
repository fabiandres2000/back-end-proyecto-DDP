using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Entity
{
    public class Paciente :Entity<int>,Persona
    {
        public string TipoAfiliacion { get; set; }
        public Medico Medico { get; set; }
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
       
        //public List<Cita> Citas { get; set; }
        public Paciente()
        {
            Edad = 0;
        }
        public Paciente(string tipoAfiliacion, Medico medico)
        {
            TipoAfiliacion = tipoAfiliacion;
            Medico = medico;
        }

        public string Guardar(Paciente paciente)
        {
            if (paciente.Identificacion == null || paciente.Nombres == null || paciente.Apellidos == null || paciente.Edad == 0 || paciente.Direccion == null || paciente.TipoAfiliacion == null)
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
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PacienteViewModels
    {
        public string TipoAfiliacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public int Estrato { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public string Municipio { get; set; }
        public string DepartamentoResidencia { get; set; }
        public Medico Medico { get; set; }
    }
}

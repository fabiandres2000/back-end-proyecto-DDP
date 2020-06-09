using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity;
namespace Domain.Factory
{
    public interface IPersonaRequest
    {
        int Type { get; set; }
        string Identificacion { get; set; }
        string Nombres { get; set; }
        string Apellidos { get; set; }
        int Edad { get; set; }
        int Estrato { get; set; }
        string Telefono { get; set; }
        string Sexo { get; set; }
        string CorreoElectronico { get; set; }
        string Direccion { get; set; }
        Municipio Municipio { get; set; }
        Departamento DepartamentoResidencia { get; set; }
        string TipoAfiliacion { get; set; }
        Medico Medico { get; set; }
        string Especializacion { get; set; }
        List<Paciente> Pacientes { get; set; }
        List<Cita> Citas { get; set; }
        List<Diagnostico> Diagnosticos { get; set; }
    }
}

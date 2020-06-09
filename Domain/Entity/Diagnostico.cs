using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Domain.Entity
{
    public class Diagnostico : Entity<int>
    {
        public string Descripcion { get; set; }
        public Enfermedad Enfermedad { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string RecomendacionMedica { get; set; }
        public Examen Examen { get; set; }

        public Tratamiento Tratamiento { get; set; }

        public Diagnostico()
        {
            
        }

        public string Guardar(Diagnostico diagnostico)
        {
            if (diagnostico.Descripcion == null || diagnostico.Paciente==null || diagnostico.Enfermedad == null || diagnostico.Estado == null || diagnostico.Medico == null || diagnostico.Enfermedad == null)
            {
                throw new InvalidOperationException("Complete todos los campos");
            }
            else
            {
                this.Descripcion = diagnostico.Descripcion;
                this.Enfermedad = diagnostico.Enfermedad;
                this.Estado = diagnostico.Estado;
                this.Medico = diagnostico.Medico;
                this.Paciente = diagnostico.Paciente;
                return "Se Registro correctamente";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain.Base;

namespace Domain.Entity
{
     public class Medico : Entity<int>,Persona
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
        public string Especializacion { get; set; }
        public List<Cita> Citas { get; set; }
    
        public  Medico()
        {
            Citas = new List<Cita>();
            Edad = 0;
        }

        public bool Verificar_disponibilidad(string fecha,int minuto,int hora)
        {
            var disponibilidad  = Citas.Where(x =>x.Fecha == fecha&& x.Minuto==minuto&&x.Hora==hora).Count();
            if (disponibilidad>=1)
            {
                return false;
            }
            return true;
        }

        public string Guardar(Medico medico)
        {
            if (medico.Identificacion == null || medico.Nombres == null || medico.Apellidos == null || medico.Edad == 0 || medico.Direccion == null || medico.Especializacion == null)
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

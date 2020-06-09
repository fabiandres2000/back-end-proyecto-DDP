using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
     public class Cita : Entity<int>
    {
       
        public string Fecha { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }  


        public string Asignar(Cita cita)
        {
            if (cita.Fecha == null || cita.Hora == null || cita.Minuto == null || cita.Medico==null || cita.Paciente==null)
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

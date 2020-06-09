using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entity;

namespace WebApi.Models
{
    public class EnfermedadSintomaViewModels
    {
       public  Enfermedad Enfermedad { get; set; }
       public  Sintoma Sintoma { get; set; }
    }
}

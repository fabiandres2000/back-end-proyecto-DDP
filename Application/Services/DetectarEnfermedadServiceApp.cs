using Domain.Contracts;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class DetectarEnfermedadServiceApp
    {
        readonly IUnitOfWork _unitOfWork;



        public DetectarEnfermedadServiceApp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public DetectarResponseapp detectar(DetectarRequestapp2 request2)
        {
            DetectarRequestapp request = new DetectarRequestapp(request2.IdPaciente, request2.Descripciones);
            var paciente_prueba = _unitOfWork.IPacienteRepository.FindBy(p => p.Identificacion == request2.IdPaciente, includeProperties: "Medico").ToList();
            var paciente = _unitOfWork.IPacienteRepository.FindFirstOrDefault(x => x.Identificacion==request.IdPaciente);
            if (paciente == null)
            {
                return new DetectarResponseapp() { Message = $"el paciente no existe" };
            }
            if (paciente.Medico == null)
            {
                return new DetectarResponseapp() { Message = $"Usted no tiene asociado un medico, por favor vaya al menu  a la opcion de --> asociar medico <-- y elija uno" };
            }
            DetectarEnfermedadService detectarEnfermedad = new DetectarEnfermedadService();
            DetectarEnfermedadRequest enfermedadRequest = new DetectarEnfermedadRequest();
            var enfermedades = _unitOfWork.EnfermedadRepository.FindBy(includeProperties:"Sintomas").ToList(); 
            enfermedadRequest.Enfermedades = enfermedades;   
            /////////////asociar sintomas a cada enfermedad//////////////////////////////////////////////////////////////////////////////
            foreach (var Item in enfermedadRequest.Enfermedades)
            {
                Console.WriteLine(Item.Nombre+" "+Item.Id);
                var enfermedadsintoma = _unitOfWork.IEnfermedadSintoma.FindBy(p=> p.Enfermedad.Codigo==Item.Codigo,includeProperties: "Sintoma,Enfermedad").ToList();  
                Console.WriteLine("sintomas asociadas de " + Item.Nombre);
                foreach (var item2 in enfermedadsintoma) {
                   Console.WriteLine(item2.Sintoma.Descripcion); 
                   Item.Sintomas.Add(item2.Sintoma); 
                }
                Console.WriteLine("---------------------------------------");
            }
            //////////////////buscar sintomas presentados por el paciente////////////////////////////////////////////////////////////////
            foreach (var item3 in request.Descripciones)
            {
                var sintomapaciente = _unitOfWork.SintomaRepository.FindFirstOrDefault(p => p.Descripcion==(item3));
                if (sintomapaciente!=null) {
                    enfermedadRequest.Sintomas.Add(sintomapaciente);
                    Console.WriteLine(sintomapaciente.Descripcion);
                }
            } 
            Console.WriteLine("numero de sistomas del paciente : "+enfermedadRequest.Sintomas.Count());
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////calcular probabilidad enfermedad//////////////////////////////////////////////////////////////////////////////
            if (enfermedadRequest.Sintomas.Count()>1)
            {
                enfermedadRequest.Paciente = paciente;
                var deteccion = detectarEnfermedad.CalcularProbabilidad(enfermedadRequest);
            //////////////////////////////////////////////////guardar el diagnostico////////////////////////////////////////////////////
                 string descripcion = "";
                  if (deteccion.Enfermedad != null)
                  {  
                    descripcion = ($"usted tiene {deteccion.Probabilidad}% de tener la enfermedad pulmonar de {deteccion.Enfermedad.Nombre}");
                    DiagnosticoRequest _diagnostico = new DiagnosticoRequest(descripcion,deteccion.Enfermedad, enfermedadRequest.Paciente, enfermedadRequest.Paciente.Medico, "pendiente",null,new DateTime());              
                    CrearDiagnosticoService serviciocreardiagnostico = new CrearDiagnosticoService(_unitOfWork);
                    serviciocreardiagnostico.CrearDiagnostico(_diagnostico);
                  }           
             ////////////////////retornamos la respuesta de la enfermedad detectada///////////////////////////////////////////////////////
                 return new DetectarResponseapp() { Message = $"se le manda tratamiento", MensajeDiagnostico = descripcion};
            }
            else
            {
                return new DetectarResponseapp() { Message = $"sus sintomas no estan asociados a una enfermedad pulmonar"};
            }
        }
    }

    public class DetectarRequestapp
    {
        public string IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public List<string> Descripciones { get; set; }

        public DetectarRequestapp(string id, List<string> des)
        {
            IdPaciente = id;
            Descripciones = des;
        }
       
    }

    public class DetectarRequestapp2
    {
        public string IdPaciente { get; set; }
        public List<string> Descripciones { get; set; }
    }

    public class DetectarResponseapp
    {
        public string Message { get; set; }
        public string MensajeDiagnostico { get; set;}
    }
}

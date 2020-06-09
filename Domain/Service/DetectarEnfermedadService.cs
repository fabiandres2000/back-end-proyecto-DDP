using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;
using System.Linq;

namespace Domain.Entity
{
    public class DetectarEnfermedadRequest
    {
        public Paciente Paciente { get; set; }
        public List<Sintoma> Sintomas = new List<Sintoma>();
        public List<Enfermedad> Enfermedades { get; set; }
    }

    public class DetectarEnfermedadResponse
    {
        public DetectarEnfermedadResponse(Enfermedad enfermedad, double probabilidad)
        {
            Enfermedad = enfermedad;
            Probabilidad = probabilidad;
        }
        public DetectarEnfermedadResponse()
        {
            Enfermedad = null;
            Probabilidad = 0;
        }

        public Enfermedad Enfermedad { get; set; }
        public double Probabilidad { get; set; }
        public bool EnfermedadDetectada => Enfermedad != null;
    }



    public class DetectarEnfermedadService : IDetectarEnfermedadService
    {
        private double Probabilidad { get; set; }
        DetectarEnfermedadRequest _request;
        public DetectarEnfermedadResponse CalcularProbabilidad(DetectarEnfermedadRequest request)
        {
            int temp = 0;
            int suma = 0;
            _request = request;
            List<double> probabilidades = new List<double>();
            List<double> probabilidades2 = new List<double>();
            var pacientes = request.Paciente;
            if (pacientes != null)
            {
                foreach (var itemEnfermedad in request.Enfermedades)
                {
                    suma = 0;
                    temp = 0;
                    foreach (var itemSintomaPaciente in request.Sintomas )
                    {
                        foreach (var itemSintomas in itemEnfermedad.Sintomas)
                        {
                            if (itemSintomas.Descripcion.Equals(itemSintomaPaciente.Descripcion))
                            {
                                suma += 1;
                            }
                        }
                        temp += 1;
                    }
                    probabilidades.Add(suma);
                    double num = (double) suma/ temp;
                    double pro = (double)num*100;
                    probabilidades2.Add(pro);
                }

                foreach (var itemEnfermedad in request.Enfermedades)
                {
                    itemEnfermedad.Sintomas.Clear();
                }

                var probabilidad = (double)probabilidades2.Max();
                Enfermedad enfermedad = Detectar(probabilidades2);
                return new DetectarEnfermedadResponse(enfermedad, probabilidad);
            }
            else
            {
                return new DetectarEnfermedadResponse();
            }
        }

        private Enfermedad Detectar(List<double> probabilidades)
        {
            int temporal = 0;
            double maximo = probabilidades.Max();
            foreach (var item in probabilidades)
            {
                if (item != maximo)
                {
                    temporal += 1;
                }
                else
                {
                    break;
                }
            }

            Enfermedad enfermedad = _request.Enfermedades.ElementAt(temporal);
            return enfermedad;
        }
    }
}

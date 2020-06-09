using Domain.Entity;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Infrastructure
{
    public class EpsContext : DbContextBase
    {

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Cita> Cita { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<EnfermedadSintoma> Diagnostico { get; set; }
        public DbSet<Enfermedad> Enfermedad { get; set; }
        public DbSet<Eps> Eps { get; set; }
        public DbSet<Examen> Examen { get; set; }
        public DbSet<HistorialCita> HistorialCita { get; set; }
        public DbSet<HistorialMedico> HistorialMedico { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Sintoma> Sintoma { get; set; }
        public DbSet<Tratamiento> Tratamiento { get; set; }
        public DbSet<EnfermedadSintoma> EnfermedadSintoma { get; set; }
        public DbSet<EnfermedadTratamiento> EnfermedadTratamiento { get; set; }
        public DbSet<ExamenDiagnostico> ExamenDiagnostico { get; set; }

        
        public EpsContext(DbContextOptions options) : base(options)
        {

        }
        
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q5U0CKK\SQLEXPRESS;Database=EpsBD;Integrated Security=True;");
        }

        
    }
}

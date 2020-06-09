using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDimension = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enfermedad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Gravedad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistorialCita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialCita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistorialMedico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialMedico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDimension = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    DepartamentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sintoma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    EnfermedadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sintoma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sintoma_Enfermedad_EnfermedadId",
                        column: x => x.EnfermedadId,
                        principalTable: "Enfermedad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tratamiento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    EnfermedadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tratamiento_Enfermedad_EnfermedadId",
                        column: x => x.EnfermedadId,
                        principalTable: "Enfermedad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Estrato = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    CorreoElectronico = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    MunicipioId = table.Column<int>(nullable: true),
                    DepartamentoResidenciaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrador_Departamento_DepartamentoResidenciaId",
                        column: x => x.DepartamentoResidenciaId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Administrador_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Estrato = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    CorreoElectronico = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    MunicipioId = table.Column<int>(nullable: true),
                    DepartamentoResidenciaId = table.Column<int>(nullable: true),
                    Especializacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medico_Departamento_DepartamentoResidenciaId",
                        column: x => x.DepartamentoResidenciaId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medico_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnfermedadSintoma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SintomaId = table.Column<int>(nullable: true),
                    EnfermedadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfermedadSintoma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnfermedadSintoma_Enfermedad_EnfermedadId",
                        column: x => x.EnfermedadId,
                        principalTable: "Enfermedad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnfermedadSintoma_Sintoma_SintomaId",
                        column: x => x.SintomaId,
                        principalTable: "Sintoma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnfermedadTratamiento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    enfermedadId = table.Column<int>(nullable: true),
                    tratamientoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfermedadTratamiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnfermedadTratamiento_Enfermedad_enfermedadId",
                        column: x => x.enfermedadId,
                        principalTable: "Enfermedad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnfermedadTratamiento_Tratamiento_tratamientoId",
                        column: x => x.tratamientoId,
                        principalTable: "Tratamiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAfiliacion = table.Column<string>(nullable: true),
                    MedicoId = table.Column<int>(nullable: true),
                    Identificacion = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Estrato = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    CorreoElectronico = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    MunicipioId = table.Column<int>(nullable: true),
                    DepartamentoResidenciaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_Departamento_DepartamentoResidenciaId",
                        column: x => x.DepartamentoResidenciaId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paciente_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paciente_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<string>(nullable: true),
                    Hora = table.Column<int>(nullable: false),
                    Minuto = table.Column<int>(nullable: false),
                    MedicoId = table.Column<int>(nullable: true),
                    PacienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cita_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cita_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    EnfermedadId = table.Column<int>(nullable: true),
                    PacienteId = table.Column<int>(nullable: true),
                    MedicoId = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    RecomendacionMedica = table.Column<string>(nullable: true),
                    ExamenId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Enfermedad_EnfermedadId",
                        column: x => x.EnfermedadId,
                        principalTable: "Enfermedad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Examen_ExamenId",
                        column: x => x.ExamenId,
                        principalTable: "Examen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamenDiagnostico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamenId = table.Column<int>(nullable: true),
                    DiagnosticoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenDiagnostico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamenDiagnostico_Diagnostico_DiagnosticoId",
                        column: x => x.DiagnosticoId,
                        principalTable: "Diagnostico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamenDiagnostico_Examen_ExamenId",
                        column: x => x.ExamenId,
                        principalTable: "Examen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_DepartamentoResidenciaId",
                table: "Administrador",
                column: "DepartamentoResidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_MunicipioId",
                table: "Administrador",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_MedicoId",
                table: "Cita",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_PacienteId",
                table: "Cita",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_EnfermedadId",
                table: "Diagnostico",
                column: "EnfermedadId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_ExamenId",
                table: "Diagnostico",
                column: "ExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_MedicoId",
                table: "Diagnostico",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_PacienteId",
                table: "Diagnostico",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EnfermedadSintoma_EnfermedadId",
                table: "EnfermedadSintoma",
                column: "EnfermedadId");

            migrationBuilder.CreateIndex(
                name: "IX_EnfermedadSintoma_SintomaId",
                table: "EnfermedadSintoma",
                column: "SintomaId");

            migrationBuilder.CreateIndex(
                name: "IX_EnfermedadTratamiento_enfermedadId",
                table: "EnfermedadTratamiento",
                column: "enfermedadId");

            migrationBuilder.CreateIndex(
                name: "IX_EnfermedadTratamiento_tratamientoId",
                table: "EnfermedadTratamiento",
                column: "tratamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenDiagnostico_DiagnosticoId",
                table: "ExamenDiagnostico",
                column: "DiagnosticoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenDiagnostico_ExamenId",
                table: "ExamenDiagnostico",
                column: "ExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_DepartamentoResidenciaId",
                table: "Medico",
                column: "DepartamentoResidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_MunicipioId",
                table: "Medico",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_DepartamentoId",
                table: "Municipio",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_DepartamentoResidenciaId",
                table: "Paciente",
                column: "DepartamentoResidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_MedicoId",
                table: "Paciente",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_MunicipioId",
                table: "Paciente",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Sintoma_EnfermedadId",
                table: "Sintoma",
                column: "EnfermedadId");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamiento_EnfermedadId",
                table: "Tratamiento",
                column: "EnfermedadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "EnfermedadSintoma");

            migrationBuilder.DropTable(
                name: "EnfermedadTratamiento");

            migrationBuilder.DropTable(
                name: "Eps");

            migrationBuilder.DropTable(
                name: "ExamenDiagnostico");

            migrationBuilder.DropTable(
                name: "HistorialCita");

            migrationBuilder.DropTable(
                name: "HistorialMedico");

            migrationBuilder.DropTable(
                name: "Sintoma");

            migrationBuilder.DropTable(
                name: "Tratamiento");

            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropTable(
                name: "Enfermedad");

            migrationBuilder.DropTable(
                name: "Examen");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}

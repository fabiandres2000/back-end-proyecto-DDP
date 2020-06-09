using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TratamientoId",
                table: "Diagnostico",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_TratamientoId",
                table: "Diagnostico",
                column: "TratamientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnostico_Tratamiento_TratamientoId",
                table: "Diagnostico",
                column: "TratamientoId",
                principalTable: "Tratamiento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnostico_Tratamiento_TratamientoId",
                table: "Diagnostico");

            migrationBuilder.DropIndex(
                name: "IX_Diagnostico_TratamientoId",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "TratamientoId",
                table: "Diagnostico");
        }
    }
}

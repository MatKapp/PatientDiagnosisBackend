using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientDiagnosis.Migrations
{
    public partial class PatientModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Patients",
                newName: "patient_surname");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Patients",
                newName: "patient_age");

            migrationBuilder.AlterColumn<string>(
                name: "patient_surname",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "patient_surname",
                table: "Patients",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "patient_age",
                table: "Patients",
                newName: "Age");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Patients",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}

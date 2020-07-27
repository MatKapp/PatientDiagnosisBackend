using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientDiagnosis.Examinations.Service.Migrations
{
    public partial class ExaminationPatientIdAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "patient_id",
                table: "Examinations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "patient_id",
                table: "Examinations");
        }
    }
}

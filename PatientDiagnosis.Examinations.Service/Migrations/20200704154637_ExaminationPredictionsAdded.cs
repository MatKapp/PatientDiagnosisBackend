using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientDiagnosis.Examinations.Service.Migrations
{
    public partial class ExaminationPredictionsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "FirstClassPrediction",
                table: "Examinations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SecondClassPrediction",
                table: "Examinations",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstClassPrediction",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "SecondClassPrediction",
                table: "Examinations");
        }
    }
}

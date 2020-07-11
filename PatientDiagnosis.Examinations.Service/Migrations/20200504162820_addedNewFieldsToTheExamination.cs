using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientDiagnosis.Examinations.Service.Migrations
{
    public partial class addedNewFieldsToTheExamination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "patient_id",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "pulse",
                table: "Examinations");

            migrationBuilder.AddColumn<bool>(
                name: "atrial_fibrillation",
                table: "Examinations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "body_weakness",
                table: "Examinations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "first_tia",
                table: "Examinations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "gait_disturb",
                table: "Examinations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "high_glucose",
                table: "Examinations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "infraction",
                table: "Examinations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "initial_dbp",
                table: "Examinations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "speech_dif",
                table: "Examinations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "vertigo",
                table: "Examinations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "atrial_fibrillation",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "body_weakness",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "first_tia",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "gait_disturb",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "high_glucose",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "infraction",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "initial_dbp",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "speech_dif",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "vertigo",
                table: "Examinations");

            migrationBuilder.AddColumn<int>(
                name: "patient_id",
                table: "Examinations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pulse",
                table: "Examinations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

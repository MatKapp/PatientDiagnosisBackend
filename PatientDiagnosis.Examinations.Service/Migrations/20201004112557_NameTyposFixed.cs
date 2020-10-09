using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientDiagnosis.Examinations.Service.Migrations
{
    public partial class NameTyposFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniWeakness_l",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "UniWeakness_r",
                table: "Examinations");

            migrationBuilder.AddColumn<bool>(
                name: "UniWeaknessL",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UniWeaknessR",
                table: "Examinations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniWeaknessL",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "UniWeaknessR",
                table: "Examinations");

            migrationBuilder.AddColumn<bool>(
                name: "UniWeakness_l",
                table: "Examinations",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UniWeakness_r",
                table: "Examinations",
                type: "boolean",
                nullable: true);
        }
    }
}

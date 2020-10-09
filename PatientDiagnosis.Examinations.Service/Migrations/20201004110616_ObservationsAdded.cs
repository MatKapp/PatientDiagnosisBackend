using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientDiagnosis.Examinations.Service.Migrations
{
    public partial class ObservationsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aphasia",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ckvalue",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Creatinevalue",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dbp",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dursymptoms",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ecgtype",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Glucosevalue",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hgbvalue",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HrRate",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ImgAbnL",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ImgAbnR",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InittiaNumpast",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedAnti",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedAsa",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedClop",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedCoum",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedDipy",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MedIbupLast7days",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedStat",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MyAfib",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MyGait",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyInfarct",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MyLang_speech",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MySensation",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MyVertigo_syncope",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MyWeakness",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PeterFlag",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pltvalue",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PmedhisAf",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PmedhisCad",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PmedhisChf",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PmedhisCs",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PmedhisDem",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PmedhisDiab",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PmedhisHchol",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PmedhisHyp",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PmedhisKps",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PmedhisPvd",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PmedhisSmoker",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PmedhisVhd",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sa02",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sbp",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Temperature",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Tntvalue",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UniWeakness_l",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UniWeakness_r",
                table: "Examinations",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Wbcvalue",
                table: "Examinations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aphasia",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Ckvalue",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Creatinevalue",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Dbp",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Dursymptoms",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Ecgtype",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Glucosevalue",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Hgbvalue",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "HrRate",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "ImgAbnL",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "ImgAbnR",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "InittiaNumpast",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MedAnti",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MedAsa",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MedClop",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MedCoum",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MedDipy",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MedIbupLast7days",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MedStat",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MyAfib",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MyGait",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MyInfarct",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MyLang_speech",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MySensation",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MyVertigo_syncope",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MyWeakness",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "PeterFlag",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Pltvalue",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "PmedhisAf",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "PmedhisCad",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "PmedhisChf",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "PmedhisCs",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "PmedhisDem",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "PmedhisDiab",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "PmedhisHchol",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "PmedhisHyp",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "PmedhisKps",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "PmedhisPvd",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "PmedhisSmoker",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "PmedhisVhd",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Sa02",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Sbp",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Tntvalue",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "UniWeakness_l",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "UniWeakness_r",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Wbcvalue",
                table: "Examinations");
        }
    }
}

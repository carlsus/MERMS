using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MERMS.Data.Migrations
{
    public partial class ConfiscationAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confiscation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrackingNo = table.Column<string>(nullable: true),
                    Jurisdiction = table.Column<string>(nullable: true),
                    DateFiled = table.Column<DateTime>(nullable: true),
                    DocketCaseNo = table.Column<string>(nullable: true),
                    CaseTitleRespondent = table.Column<string>(nullable: true),
                    NatureOfViolation = table.Column<string>(nullable: true),
                    CourtFiled = table.Column<string>(nullable: true),
                    VehiclePlateNo = table.Column<string>(nullable: true),
                    KindSpecies = table.Column<string>(nullable: true),
                    EstimatedValue = table.Column<double>(nullable: true),
                    ForestProductStockPiled = table.Column<string>(nullable: true),
                    BoardFeet = table.Column<double>(nullable: true),
                    CubicMeter = table.Column<double>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confiscation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confiscation");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MERMS.Data.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficeNo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ApprehensionConfiscations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Jurisdiction = table.Column<string>(nullable: true),
                    PlaceOfApprehension = table.Column<string>(nullable: true),
                    DateOfConfiscation = table.Column<DateTime>(nullable: true),
                    NumberOfPieces = table.Column<int>(nullable: false),
                    Species = table.Column<string>(nullable: true),
                    BoardFeet = table.Column<string>(nullable: true),
                    CubicMeter = table.Column<string>(nullable: true),
                    VehiclePlateNo = table.Column<string>(nullable: true),
                    ParaphernaliaSerialNo = table.Column<string>(nullable: true),
                    Offender = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Custodian = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    EstimatedValue = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprehensionConfiscations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprehensionConfiscations");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OfficeNo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}

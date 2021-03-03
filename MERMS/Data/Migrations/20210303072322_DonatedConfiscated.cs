using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MERMS.Data.Migrations
{
    public partial class DonatedConfiscated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonatedConfiscateds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfDonation = table.Column<DateTime>(nullable: false),
                    DoneeRecipient = table.Column<string>(nullable: true),
                    NumberOfPieces = table.Column<int>(nullable: false),
                    VolumeBoardFeet = table.Column<string>(nullable: true),
                    EstimatedMarketValue = table.Column<double>(nullable: false),
                    Purpose = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonatedConfiscateds", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonatedConfiscateds");
        }
    }
}

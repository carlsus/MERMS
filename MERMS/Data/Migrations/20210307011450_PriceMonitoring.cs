using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MERMS.Data.Migrations
{
    public partial class PriceMonitoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "PriceMonitorings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrackingNo = table.Column<string>(nullable: true),
                    CenroConcerned = table.Column<string>(nullable: true),
                    ReleasedCenro = table.Column<DateTime>(nullable: false),
                    ReceivedPenro = table.Column<DateTime>(nullable: false),
                    CenroReport = table.Column<string>(nullable: true)
                   
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMonitorings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceMonitorings");

        }
    }
}

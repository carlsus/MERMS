using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MERMS.Data.Migrations
{
    public partial class PriceMonitoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "TrackingNo",
            //    table: "MultiForestProtections",
            //    nullable: true);

            //migrationBuilder.AlterColumn<double>(
            //    name: "VolumeBoardFeet",
            //    table: "DonatedConfiscateds",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "TEXT",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "TrackingNo",
            //    table: "DonatedConfiscateds",
            //    nullable: true);

            //migrationBuilder.AlterColumn<double>(
            //    name: "CubicMeter",
            //    table: "Confiscation",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "TEXT",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<double>(
            //    name: "BoardFeet",
            //    table: "Confiscation",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "TEXT",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "TrackingNo",
            //    table: "Confiscation",
            //    nullable: true);

            //migrationBuilder.AlterColumn<double>(
            //    name: "CubicMeter",
            //    table: "ApprehensionConfiscations",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "TEXT",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<double>(
            //    name: "BoardFeet",
            //    table: "ApprehensionConfiscations",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "TEXT",
            //    oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PriceMonitorings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Month = table.Column<DateTime>(nullable: false),
                    CenroConcerned = table.Column<string>(nullable: true),
                    ReleasedCenro = table.Column<DateTime>(nullable: false),
                    ReceivedPenro = table.Column<DateTime>(nullable: false),
                    CenroReport = table.Column<string>(nullable: true),
                    PenroReport = table.Column<string>(nullable: true),
                    DateOfSubmission = table.Column<DateTime>(nullable: false)
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

            //migrationBuilder.DropColumn(
            //    name: "TrackingNo",
            //    table: "MultiForestProtections");

            //migrationBuilder.DropColumn(
            //    name: "TrackingNo",
            //    table: "DonatedConfiscateds");

            //migrationBuilder.DropColumn(
            //    name: "TrackingNo",
            //    table: "Confiscation");

            //migrationBuilder.AlterColumn<string>(
            //    name: "VolumeBoardFeet",
            //    table: "DonatedConfiscateds",
            //    type: "TEXT",
            //    nullable: true,
            //    oldClrType: typeof(double));

            //migrationBuilder.AlterColumn<string>(
            //    name: "CubicMeter",
            //    table: "Confiscation",
            //    type: "TEXT",
            //    nullable: true,
            //    oldClrType: typeof(double));

            //migrationBuilder.AlterColumn<string>(
            //    name: "BoardFeet",
            //    table: "Confiscation",
            //    type: "TEXT",
            //    nullable: true,
            //    oldClrType: typeof(double));

            //migrationBuilder.AlterColumn<string>(
            //    name: "CubicMeter",
            //    table: "ApprehensionConfiscations",
            //    type: "TEXT",
            //    nullable: true,
            //    oldClrType: typeof(double));

            //migrationBuilder.AlterColumn<string>(
            //    name: "BoardFeet",
            //    table: "ApprehensionConfiscations",
            //    type: "TEXT",
            //    nullable: true,
            //    oldClrType: typeof(double));
        }
    }
}

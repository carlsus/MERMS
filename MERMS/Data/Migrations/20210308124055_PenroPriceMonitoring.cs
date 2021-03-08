using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MERMS.Data.Migrations
{
    public partial class PenroPriceMonitoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "DateOfSubmission",
            //    table: "PriceMonitorings");

            //migrationBuilder.DropColumn(
            //    name: "Month",
            //    table: "PriceMonitorings");

            //migrationBuilder.DropColumn(
            //    name: "PenroReport",
            //    table: "PriceMonitorings");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "ReleasedCenro",
            //    table: "PriceMonitorings",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "TEXT");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "ReceivedPenro",
            //    table: "PriceMonitorings",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "TEXT");

            //migrationBuilder.AddColumn<string>(
            //    name: "TrackingNo",
            //    table: "PriceMonitorings",
            //    nullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "DateOfMeeting",
            //    table: "MultiForestProtections",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "TEXT");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "DateOfDonation",
            //    table: "DonatedConfiscateds",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "PenroPriceMonitorings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrackingNo = table.Column<string>(nullable: true),
                    ReleasedPenro = table.Column<DateTime>(nullable: false),
                    PenroReport = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenroPriceMonitorings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PenroPriceMonitorings");

            //migrationBuilder.DropColumn(
            //    name: "TrackingNo",
            //    table: "PriceMonitorings");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "ReleasedCenro",
            //    table: "PriceMonitorings",
            //    type: "TEXT",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "ReceivedPenro",
            //    table: "PriceMonitorings",
            //    type: "TEXT",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldNullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "DateOfSubmission",
            //    table: "PriceMonitorings",
            //    type: "TEXT",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "Month",
            //    table: "PriceMonitorings",
            //    type: "TEXT",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<string>(
            //    name: "PenroReport",
            //    table: "PriceMonitorings",
            //    type: "TEXT",
            //    nullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "DateOfMeeting",
            //    table: "MultiForestProtections",
            //    type: "TEXT",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "DateOfDonation",
            //    table: "DonatedConfiscateds",
            //    type: "TEXT",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldNullable: true);
        }
    }
}

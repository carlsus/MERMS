using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MERMS.Data.Migrations
{
    public partial class MultiForest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MultiForestProtections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrackingNo = table.Column<string>(nullable: true),
                    DateOfMeeting = table.Column<DateTime>(nullable: false),
                    VenueOfMeeting = table.Column<string>(nullable: true),
                    NumberOfAttendees = table.Column<int>(nullable: false),
                    LetterOfInvitation = table.Column<string>(nullable: true),
                    AttendanceSheet = table.Column<string>(nullable: true),
                    MinutesOfMeeting = table.Column<string>(nullable: true),
                    PhotoDocumentation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiForestProtections", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MultiForestProtections");
        }
    }
}

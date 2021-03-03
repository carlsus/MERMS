using Microsoft.EntityFrameworkCore.Migrations;

namespace MERMS.Data.Migrations
{
    public partial class DonatedConfiscated_add_file_path : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "DonatedConfiscateds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "DonatedConfiscateds");
        }
    }
}

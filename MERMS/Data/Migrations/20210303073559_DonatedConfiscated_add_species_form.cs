using Microsoft.EntityFrameworkCore.Migrations;

namespace MERMS.Data.Migrations
{
    public partial class DonatedConfiscated_add_species_form : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpeciesForm",
                table: "DonatedConfiscateds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpeciesForm",
                table: "DonatedConfiscateds");
        }
    }
}

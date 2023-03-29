using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PotentialForAfrica.Data.Migrations
{
    public partial class modifier_colonne_NOmCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomCV",
                table: "Candidats");

            migrationBuilder.AddColumn<string>(
                name: "CVPath",
                table: "Candidats",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVPath",
                table: "Candidats");

            migrationBuilder.AddColumn<string>(
                name: "NomCV",
                table: "Candidats",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PotentialForAfrica.Data.Migrations
{
    public partial class CanadiatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidats",
                columns: table => new
                {
                    CandidatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telehone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NiveauEtude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NbreAnneeExperience = table.Column<int>(type: "int", nullable: false),
                    DernierEmployeur = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomCV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidats", x => x.CandidatId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidats");
        }
    }
}

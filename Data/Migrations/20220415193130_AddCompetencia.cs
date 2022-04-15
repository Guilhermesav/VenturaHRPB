using Microsoft.EntityFrameworkCore.Migrations;

namespace VenturaHRPB.Data.Migrations
{
    public partial class AddCompetencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Competencias",
                table: "VagasModel");

            migrationBuilder.CreateTable(
                name: "CompetenciaModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Peso = table.Column<float>(nullable: false),
                    VagasModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciaModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenciaModel_VagasModel_VagasModelId",
                        column: x => x.VagasModelId,
                        principalTable: "VagasModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciaModel_VagasModelId",
                table: "CompetenciaModel",
                column: "VagasModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetenciaModel");

            migrationBuilder.AddColumn<string>(
                name: "Competencias",
                table: "VagasModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

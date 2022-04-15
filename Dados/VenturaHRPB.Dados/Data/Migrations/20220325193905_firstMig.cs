using Microsoft.EntityFrameworkCore.Migrations;

namespace VenturaHRPB.Data.Migrations
{
    public partial class firstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VagasModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Competencias = table.Column<string>(nullable: true),
                    Empresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VagasModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidatoModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Qualificações = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    VagasModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatoModel_VagasModel_VagasModelId",
                        column: x => x.VagasModelId,
                        principalTable: "VagasModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoModel_VagasModelId",
                table: "CandidatoModel",
                column: "VagasModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoModel");

            migrationBuilder.DropTable(
                name: "VagasModel");
        }
    }
}

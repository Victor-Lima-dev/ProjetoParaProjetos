using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoParaProjetos.Migrations
{
    /// <inheritdoc />
    public partial class casosclinicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CasoClinicoId",
                table: "Questoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CasosClinicos",
                columns: table => new
                {
                    CasoClinicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Caso = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasosClinicos", x => x.CasoClinicoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_CasoClinicoId",
                table: "Questoes",
                column: "CasoClinicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questoes_CasosClinicos_CasoClinicoId",
                table: "Questoes",
                column: "CasoClinicoId",
                principalTable: "CasosClinicos",
                principalColumn: "CasoClinicoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questoes_CasosClinicos_CasoClinicoId",
                table: "Questoes");

            migrationBuilder.DropTable(
                name: "CasosClinicos");

            migrationBuilder.DropIndex(
                name: "IX_Questoes_CasoClinicoId",
                table: "Questoes");

            migrationBuilder.DropColumn(
                name: "CasoClinicoId",
                table: "Questoes");
        }
    }
}
